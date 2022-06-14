using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static APIVersioning.TodoModel;

namespace APIVersioning.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiVersion("1.0",Deprecated = true)]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    public class WeatherForecastController : ControllerBase,ITodo
    {
        private static List<TodoDTO> TodoData = null;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IConfiguration _configuration)
        {
            _logger = logger;
            TodoData = JsonConvert.DeserializeObject<List<TodoDTO>>("[{\"id\":1,\"text\":\"LearnaboutPolymer\",\"created_at\":\"MonApr2606:01:55+00002015\",\"Tags\":[\"WebDevelopment\",\"WebComponents\"],\"is_complete\":true},{\"id\":2,\"text\":\"WatchPluralsightcourseonDocker\",\"created_at\":\"TueMar0207:01:55+00002015\",\"Tags\":[\"Devops\",\"Docker\"],\"is_complete\":true},{\"id\":3,\"text\":\"CompletepresentationprepforAureliapresentation\",\"created_at\":\"WedMar0510:01:55+00002015\",\"Tags\":[\"Presentation\",\"Aureia\"],\"is_complete\":false},{\"id\":4,\"text\":\"InstrumentcreationofdevelopmentenvironmentwithPuppet\",\"created_at\":\"FriJune3013:00:00+00002015\",\"Tags\":[\"Devops\",\"Puppet\"],\"is_complete\":false},{\"id\":5,\"text\":\"TransitioncodebasetoES6\",\"created_at\":\"MonAug0110:00:00+00002015\",\"Tags\":[\"ES6\",\"WebDevelopment\"],\"is_complete\":false}]");
        }


        //Query String Parameter Versioning
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IEnumerable<TodoDTO> GetAllTodo()
        {
            return TodoData.ToList();
        }
        
        [HttpGet()]
        [MapToApiVersion("2.0")]
        public IEnumerable<TodoData> GetTodoList()
        {
            return TodoData.Select(x => new TodoData()
            {
                Text = x.Text,
                Created_at = x.Created_at,
                Is_complete = x.Is_complete
            });
        }

        //Default Version
        [HttpGet]
        public IEnumerable<TodoDTO> GetAllInCompleteTodo()
        {
            return TodoData.Where(x => x.Is_complete == false);
        }

        //Default Version
        [HttpGet]
        public IEnumerable<TodoDTO> GetAllCompletedTask()
        {
            return TodoData.Where(x => x.Is_complete == true);
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public TodoDTO GetTodoByID(int ID)
        {
            return TodoData.FirstOrDefault(x => x.Id == ID);
        }


        //Media/Header API Versioning
        [HttpGet]
        [MapToApiVersion("3.0")]
        public IEnumerable<TodoDTO> Search(string text)
        {
            return TodoData.Where(x => x.Text.ToLower().Contains(text));
        }
    }
}
