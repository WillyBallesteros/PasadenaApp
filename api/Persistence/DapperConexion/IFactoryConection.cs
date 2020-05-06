using System.Data;

namespace Persistence.DapperConexion
{
    public interface IFactoryConection
    {
        public void CloseConnection();
        public IDbConnection GetConnection();
    }
}
