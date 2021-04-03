using GrowTogether.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GrowTogether.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly GrowDbContext _context = null;
        public AuthService(IOptions<AppSettings> appSettings, GrowDbContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        // private List<User> admin = new List<User>()
        // {
        //     new User {UserID=1,UserName="sanjana",Password="sanjana"},
        //     new User {UserID=2,UserName="krupali",Password="krupali"},
        // };

        public User Authenticate(string userName, string password)
        {
            //var user = users.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            var user = _context.User.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
            User nuser = new User();

            //if user not fouund
            if (user == null)
                return null;
            // if user found

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1"),

                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            //because we don't want any other user to access password 
            user.Password = null;
            return user;
        }

        User IAuthService.RegisterUser(string userName, string password, string fname, string lname, string confirmPassword, string avtar)
        {
            try
            {
                var user = new User()
                {
                    UserName = userName,
                    Password = password,
                    FirstName = fname,
                    LastName = lname,
                    ConfirmPassword = confirmPassword,
                    Avtar = avtar,
                };
                
                    _context.User.Add(user);
                    _context.SaveChanges();
                
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
