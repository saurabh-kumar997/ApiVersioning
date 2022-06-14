using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVersioning
{
    public class TodoModel
    {
        public class TodoDTO
        {
            public TodoDTO()
            {
                Tags = new List<string>();
            }
            public int Id { get; set; }
            public string Text { get; set; }
            public string Created_at { get; set; }
            public List<string> Tags { get; set; }
            public bool Is_complete { get; set; }
        }

        public class TodoData
        {
            public string Text { get; set; }
            public string Created_at { get; set; }
            public bool Is_complete { get; set; }
        }
    }
}
