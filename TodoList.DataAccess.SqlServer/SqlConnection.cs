using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TodoList.DataAccess.SqlServer;

public static class SqlConnectionProvider
{
    public static IDbConnection CreateDbConnection(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("SQLServerConnectionString");
        IDbConnection cn = new SqlConnection(connectionString);
        return cn;
    }
}
