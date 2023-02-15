using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace TodoList.DataAccess; public class DataAccess : IDataAccess
{
    public IDbConnection CreateSqlServerConnection()
    {
        var cnString = @"Server=.\MSSQLSERVER;Database=TodoList;Trusted_Connection=True;";
        return new SqlConnection(cnString);
    }

    public IEnumerable<dynamic> GetAll()
    {
        var sql = "SELECT * FROM TodoList";

        using IDbConnection cn = CreateSqlServerConnection();

        IEnumerable<dynamic> result = cn.Query(sql, commandType: CommandType.Text);

        return result;
    }

}