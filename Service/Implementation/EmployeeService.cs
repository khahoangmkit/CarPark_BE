using Service1.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using Model.Repository;

namespace Service1.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(IGenericRepository<Employee> emmplEmployeeRepository)
        {
            _employeeRepository = emmplEmployeeRepository;
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _employeeRepository.Create(employee).ConfigureAwait(false);
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