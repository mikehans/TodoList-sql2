using System.Data;

namespace TodoList.DataAccess
{
    public interface IDataAccess
    {
        IDbConnection CreateSqlServerConnection();
        IEnumerable<dynamic> GetAll();
    }
}
