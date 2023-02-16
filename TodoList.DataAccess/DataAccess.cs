using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using TodoList.DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace TodoList.DataAccess;

public class DataAccess : IDataAccess
{
    private readonly string _cnString;

    public DataAccess(IConfiguration configuration)
    {
        var cnstr = configuration.GetConnectionString("DefaultConnection");
        if(String.IsNullOrEmpty(cnstr)){
            throw new Exception("No DefaultConnection in connection strings");
        }
        _cnString = cnstr;
    }
    public IEnumerable<TodoItem> GetAll()
    {
        var sql = "SELECT * FROM TodoList";

        using IDbConnection cn = new SqlConnection(_cnString);

        IEnumerable<TodoItem> result = cn.Query<TodoItem>(sql, commandType: CommandType.Text);

        return result;
    }

    public int CreateTodo()
    {
        using IDbConnection cn = new SqlConnection(_cnString);

        var newTodo = new TodoItemForInsert()
        {
            Title = "Feed the lion",
            Description = "With the horse"
        };

        int v = cn.Execute("sp_CreateTodo", newTodo, commandType: CommandType.StoredProcedure);

        return v;
    }
}