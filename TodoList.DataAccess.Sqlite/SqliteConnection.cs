using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace TodoList.DataAccess.Sqlite;

public class SqliteConnectionProvider :IDisposable
{
    private static IDbConnection cn;
    public static IDbConnection CreateInMemoryDbConnection(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLiteInMemoryConnectionString");
        cn = new SqliteConnection(connectionString);
        return cn;
    }
    
    public static IDbConnection CreateDbConnection(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLiteConnectionString");
        cn = new SqliteConnection(connectionString);
        return cn;
    }

    public void Dispose()
    {
        Console.WriteLine($"{nameof(SqliteConnectionProvider)}.Dispose()");
    }
}