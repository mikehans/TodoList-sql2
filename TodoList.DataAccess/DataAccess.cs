using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using TodoList.DataAccess.Models;

namespace TodoList.DataAccess;

public class DataAccess : IDataAccess
{
    public delegate IDbConnection CreateDbConnection(IConfiguration config);

    private readonly CreateDbConnection _connect;
    private readonly IConfiguration _config;

    public DataAccess(CreateDbConnection connect, IConfiguration config)
    {
        _connect = connect;
        _config = config;
    }
    public IEnumerable<TodoItem> GetAll()
    {
        var sql = "SELECT * FROM TodoList";

        var cn = _connect(_config);
        IEnumerable<TodoItem> result = cn.Query<TodoItem>(sql, commandType: CommandType.Text);

        return result;
    }

    public int CreateTodo()
    {
        var cn = _connect(_config);

        var newTodo = new TodoItemForInsert()
        {
            Title = "Feed the oil rig",
            Description = "With the T-Rex"
        };

        var rowsAffected = cn.Execute("sp_CreateTodo", newTodo, commandType: CommandType.StoredProcedure);

        return rowsAffected;
    }
}