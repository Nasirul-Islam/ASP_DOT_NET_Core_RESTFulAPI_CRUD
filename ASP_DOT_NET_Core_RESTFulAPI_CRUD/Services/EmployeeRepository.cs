using Dapper;
using System.Collections.Generic;
using System.Data;
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
        private const string StoredProcedureName = "sp_ManageEmpInfo";
        
        // Fetch all employees or a specific employee by ID
        public async Task<IEnumerable<EmployeeInfo>> GetAllEmployeesAsync(int? empId = null)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                //var query = "SELECT * FROM EmpInfo";
                //return await connection.QueryAsync<EmployeeInfo>(query);
                var parameters = new DynamicParameters();
                parameters.Add("@Action", "GET", DbType.String);
                parameters.Add("@EmpID", empId, DbType.Int32);

                return await connection.QueryAsync<EmployeeInfo>(
                    StoredProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        // Insert a new employee
        public async Task<int> AddEmployeeAsync(EmployeeInfo employee)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Action", "INSERT", DbType.String);
                parameters.Add("@FirstName", employee.FirstName, DbType.String);
                parameters.Add("@LastName", employee.LastName, DbType.String);
                parameters.Add("@Email", employee.Email, DbType.String);
                parameters.Add("@PhoneNumber", employee.PhoneNumber, DbType.String);
                parameters.Add("@DateOfBirth", employee.DateOfBirth, DbType.Date);
                parameters.Add("@HireDate", employee.HireDate, DbType.Date);
                parameters.Add("@JobTitle", employee.JobTitle, DbType.String);
                parameters.Add("@Department", employee.Department, DbType.String);
                parameters.Add("@Salary", employee.Salary, DbType.Decimal);
                parameters.Add("@Address", employee.Address, DbType.String);
                parameters.Add("@City", employee.City, DbType.String);
                parameters.Add("@State", employee.State, DbType.String);
                parameters.Add("@PostalCode", employee.PostalCode, DbType.String);
                parameters.Add("@Country", employee.Country, DbType.String);
                parameters.Add("@IsActive", employee.IsActive, DbType.Boolean);

                return await connection.ExecuteAsync(
                    StoredProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        // Update an existing employee
        public async Task<int> UpdateEmployeeAsync(EmployeeInfo employee)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Action", "UPDATE", DbType.String);
                parameters.Add("@EmpID", employee.EmpID, DbType.Int32);
                parameters.Add("@FirstName", employee.FirstName, DbType.String);
                parameters.Add("@LastName", employee.LastName, DbType.String);
                parameters.Add("@Email", employee.Email, DbType.String);
                parameters.Add("@PhoneNumber", employee.PhoneNumber, DbType.String);
                parameters.Add("@DateOfBirth", employee.DateOfBirth, DbType.Date);
                parameters.Add("@HireDate", employee.HireDate, DbType.Date);
                parameters.Add("@JobTitle", employee.JobTitle, DbType.String);
                parameters.Add("@Department", employee.Department, DbType.String);
                parameters.Add("@Salary", employee.Salary, DbType.Decimal);
                parameters.Add("@Address", employee.Address, DbType.String);
                parameters.Add("@City", employee.City, DbType.String);
                parameters.Add("@State", employee.State, DbType.String);
                parameters.Add("@PostalCode", employee.PostalCode, DbType.String);
                parameters.Add("@Country", employee.Country, DbType.String);
                parameters.Add("@IsActive", employee.IsActive, DbType.Boolean);

                return await connection.ExecuteAsync(
                    StoredProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        // Delete an employee by ID
        public async Task<int> DeleteEmployeeAsync(int empId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Action", "DELETE", DbType.String);
                parameters.Add("@EmpID", empId, DbType.Int32);

                return await connection.ExecuteAsync(
                    StoredProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
