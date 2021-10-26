using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Service1.Interface
{
    public interface IEmployeeService
    {
        public Task<Employee> CreateEmployee(Employee employee);
        public Task<string> DeleteEmployee(int employeeId);
        public Task<Employee> UpdateEmployee(Employee employee);
        public Task<List<Employee>> GetAllEmployee();
        public Task<Employee> GetEmployeeById(int employeeId);
    }
}
