using Service1.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Entity;
using Model.Repository;
using BC = BCrypt.Net;

namespace Service1.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<Employee> _employeeRepository;

        private readonly string tokenKey;

        public AuthenticationService(IConfiguration configuration, IGenericRepository<Employee> employeeRepository)
        {
            _configuration = configuration;
            _employeeRepository = employeeRepository;
        }

        public string login(string username, string password)
        {
            var employee =  _employeeRepository.FindByCondition(e => e.Account == username).FirstOrDefault();
            
            if (employee == null || !BC.BCrypt.Verify(password, employee.Password))
            {
                return null;
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["TokenKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, employee.Account),
                    new Claim("FullName", employee.Account)
                    
                }),
                Expires = DateTime.UtcNow.AddHours(100),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}