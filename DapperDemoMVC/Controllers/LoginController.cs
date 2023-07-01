using DapperDemoMVC.Infrastructure;
using DapperDemoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemoMVC.Controllers
{
    public class LoginController : Controller
    {
        private string _connectionString;
        private IConfiguration _configuration;
        private IRepository _repository;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnectionString")!;
            _repository = new Repository(_connectionString);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginCredentialsModel loginCredentials)
        {
            if(loginCredentials != null)
            {
                var isValidCredentials = _repository.VerifyLogin(loginCredentials);
                if (isValidCredentials)
                {
                    return View("Success", "Login");
                }
            }
            TempData["LoginError"] = "Invalid Username or Password!";
            return RedirectToAction("Login");
        }
    }
}
