using AspMvcChat.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcChat.Controllers
{
    public class HomeController : Controller
    {
        // Add EF DataBase
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        // Index Page
        public IActionResult Index()
        {
            ViewBag.Users = db.Users.ToList();
            return View();
        }

        // Register Controller
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public string Register(string login, string password)
        {
            db.Users.Add(new User() {
                Login = login,
                Password = password
            });
            db.SaveChanges();

            return "added";
        }

        // Login Controller
        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies.ContainsKey("login") &&
                Request.Cookies.ContainsKey("password"))
            {
                string cookieLogin = Request.Cookies["login"];
                string cookiesPassword = Request.Cookies["password"];

                if (db.Users.Any(a => a.Login == cookieLogin && a.Password == cookiesPassword))
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            if (db.Users.Any(a => a.Login == login && a.Password == password))
            {
                Response.Cookies.Append("login", login);
                Response.Cookies.Append("password", password);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
