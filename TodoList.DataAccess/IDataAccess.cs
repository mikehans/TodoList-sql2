using System.Data;
using TodoList.DataAccess.Models;

namespace TodoList.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<TodoItem> GetAll();

        int CreateTodo();
    }
}
