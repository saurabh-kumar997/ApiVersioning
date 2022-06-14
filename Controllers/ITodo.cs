using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static APIVersioning.TodoModel;


namespace APIVersioning.Controllers
{
    interface ITodo
    {
        IEnumerable<TodoDTO> GetAllTodo();
        IEnumerable<TodoDTO> GetAllInCompleteTodo();
        IEnumerable<TodoDTO> GetAllCompletedTask();
        TodoDTO GetTodoByID(int ID);
        IEnumerable<TodoDTO> Search(string text);
    }
}
