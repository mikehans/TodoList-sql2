using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace TodoList.DataAccess.Sqlite;

public static class SqliteConnectionProvider
{
    public static IDbConnection CreateDbConnection(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLiteInMemoryConnectionString");
        var cn = new SqliteConnection(connectionString);
        return cn;
    }
}