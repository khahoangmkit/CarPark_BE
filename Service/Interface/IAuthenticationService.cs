using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service1.Interface
{
    public interface IAuthenticationService
    {
        string login(string username, string password);
    }
}
