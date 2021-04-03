using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowTogether.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avtar { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string  Token { get; set; }
    }
}
