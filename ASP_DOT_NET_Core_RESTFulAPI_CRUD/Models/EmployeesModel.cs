namespace ASP_DOT_NET_Core_RESTFulAPI_CRUD.Models
{
    public class EmployeesModel
    {
        public class EmployeeInfo
        {
            public int EmpID { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public DateTime HireDate { get; set; }
            public string? JobTitle { get; set; }
            public string? Department { get; set; }
            public decimal? Salary { get; set; }
            public string? Address { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? PostalCode { get; set; }
            public string? Country { get; set; }
            public bool IsActive { get; set; } = true;
            public DateTime CreatedDate { get; set; } = DateTime.Now;
            public DateTime UpdatedDate { get; set; } = DateTime.Now;
        }
    }
}
