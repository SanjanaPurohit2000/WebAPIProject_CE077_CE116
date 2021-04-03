using GrowTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowTogether.Services
{
    public interface IAuthService
    {
        User Authenticate(string userName, string password);
        User RegisterUser(string userName, string password, string fname, string lname, string confirmPassword, string avtar);
    }
}