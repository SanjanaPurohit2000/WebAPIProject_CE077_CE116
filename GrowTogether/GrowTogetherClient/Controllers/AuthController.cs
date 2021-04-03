using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GrowTogetherClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GrowTogetherClient.Controllers
{
    public class AuthController : Controller
    {

        private static readonly HttpClient client = new HttpClient();


        // GET: LoginController/Create
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult UploadFiles()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> UploadFilesAsync(IFormCollection collection)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44302/api/account/login");
            Material file = new Material();
            file.Name = collection["Name"];
            file.Path = collection["Path"];
            var myContent = JsonConvert.SerializeObject(file);
            var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:44373/FileUpload", stringContent);
            string result = response.Content.ReadAsStringAsync().Result;
            var files = JsonConvert.DeserializeObject<Material>(result);
            //return Json(user);
            if (files != null)
            {
                
                return RedirectToAction("Home", "Index");
            }
            else
            {
                return View();
            }
           
        }
        // POST: LoginController/Create
        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(IFormCollection collection)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44302/api/account/login");
            User register = new User();
            register.UserName = collection["UserName"];
            register.Password = collection["Password"];
          

            var myContent = JsonConvert.SerializeObject(register);
            var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:44373/Authentication/Login", stringContent);
            string result = response.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(result);
            //return Json(user);
            if (user != null)
            {
                HttpContext.Session.SetString("Token", user.Token.ToString());
                return RedirectToAction("Home","Index");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(IFormCollection collection)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44302/api/account/login");
            User register = new User();
            register.UserName = collection["UserName"];
            register.Password = collection["Password"];
            register.FirstName = collection["FirstName"];
            register.LastName = collection["LastName"];
   
            var myContent = JsonConvert.SerializeObject(register);
            var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:44373/Authentication/Register", stringContent);
            string result = response.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(result);
            //return Json(user);
            if (user != null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }


    }
}
