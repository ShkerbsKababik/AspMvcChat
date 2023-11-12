using Microsoft.AspNetCore.Mvc;

namespace AspMvcChat.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public string Register(string login, string password)
        {        
            return $"{login} {password}";
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public string Login(string login, string password)
        {
            return $"{login} {password}";
        }
    }
}
