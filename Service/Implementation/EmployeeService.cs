using Service1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using Model.Repository;
using BC = BCrypt.Net;

namespace Service1.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(IGenericRepository<Employee> emmplEmployeeRepository)
        {
            _employeeRepository = emmplEmployeeRepository;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var _employeeTemp = _employeeRepository.FindByCondition(e => e.Account == employee.Account).FirstOrDefault();
            if (_employeeTemp != null ) return null;
            employee.Password = BC.BCrypt.HashPassword(employee.Password);
            await _employeeRepository.Create(employee).ConfigureAwait(false);
            return employee;
        }

        public async Task<string> DeleteEmployee(int employeeId)
        {
            var employee = await _employeeRepository.GetById(employeeId).ConfigureAwait(false);
            if (employee != null)
            {
                await _employeeRepository.Delete(employee).ConfigureAwait(false);
                return "Delete successful!";
            }
            else
            {
                return "Can't find Employee!";
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var _employee = await _employeeRepository.GetById(employee.Id);
            if (_employee != null)
            {
                _employee.Account = employee.Account;
                _employee.Address = employee.Address;
                _employee.Email = employee.Email;
                _employee.Department = employee.Department;
                _employee.Password = employee.Password;
                _employee.Phone = employee.Phone;
                _employee.Sex = employee.Sex;
                _employee.FullName = employee.FullName;
                _employee.DateOfBirth = employee.DateOfBirth;
                
                await _employeeRepository.Update(_employee).ConfigureAwait(false);
            }

            return _employee;
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _employeeRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _employeeRepository.GetById(employeeId).ConfigureAwait(false);
        }
    }
}