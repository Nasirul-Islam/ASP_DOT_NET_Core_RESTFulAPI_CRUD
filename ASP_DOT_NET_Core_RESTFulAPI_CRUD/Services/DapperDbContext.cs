using System.Data;
using Microsoft.Data.SqlClient;

namespace ASP_DOT_NET_Core_RESTFulAPI_CRUD.Services
{
    public class DapperDbContext
    {
        //private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        public DapperDbContext(IConfiguration configuration)
        {
            //_configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
