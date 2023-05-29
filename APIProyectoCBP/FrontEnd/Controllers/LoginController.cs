using FrontEnd.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace FrontEnd.Controllers
{
    public class LoginController :  Controller
    {
        private readonly ILogin _loginUser;

        public LoginController(ILogin loguser)
        {
            _loginUser = loguser;
        }

        public IActionResult Index() { 
            
            return View();

        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {

            var issuccess = _loginUser.AuthenticateUser(username, password);

            if (issuccess.Result != null)
            {

                ViewBag.username = string.Format("Successfully logged-in", username);

                TempData["username"] = "Byron";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
               // return View();
                return RedirectToAction("Login", "Home");
            }
        }
    }
}
