using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TodoList.DataAccess.SqlServer;

public class SqlConnectionProvider : IDisposable
{
    static IDbConnection cn;

    public static IDbConnection CreateDbConnection(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("SQLServerConnectionString");
        cn = new SqlConnection(connectionString);
        return cn;
    }

    public void Dispose()
    {
        Console.WriteLine($"{nameof(SqlConnectionProvider)}.Dispose()");
    }
}
