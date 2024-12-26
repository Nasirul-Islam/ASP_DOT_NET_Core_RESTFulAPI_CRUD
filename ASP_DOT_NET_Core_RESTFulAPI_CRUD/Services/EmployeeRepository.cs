using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ASP_DOT_NET_Core_RESTFulAPI_CRUD.Models.EmployeesModel;

namespace ASP_DOT_NET_Core_RESTFulAPI_CRUD.Services
{
    public class EmployeeRepository
    {
        private readonly DapperDbContext _dbContext;
        public EmployeeRepository(DapperDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public async Task<IEnumerable<EmployeeInfo>> GetAllEmployeesAsync()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var query = "SELECT * FROM EmpInfo";
                return await connection.QueryAsync<EmployeeInfo>(query);
            }
        }
        public async Task<EmployeeInfo> GetEmployeeByIdAsync(int id)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var query = "SELECT * FROM Products WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<EmployeeInfo>(query, new { Id = id });
            }
        }

        public async Task<int> AddEmployeeAsync(EmployeeInfo product)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
                return await connection.ExecuteAsync(query, product);
            }
        }
    }
}
