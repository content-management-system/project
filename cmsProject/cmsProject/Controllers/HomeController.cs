using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cmsProject.Models;
using Microsoft.AspNetCore.Http;

namespace cmsProject.Controllers
{
    public class HomeController : Controller
    {
        private cmsDbContext _context;
        public HomeController(cmsDbContext context)
        {
            _context = context;
        }

        //private readonly ILogger<HomeController> _logger;
        
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                _context.UserAccounts.Add(user);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message =user.FirstName+" "+user.LastName+" is Successfully Registered!";
               
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            var account = _context.UserAccounts.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UserId", account.UserId.ToString());
                HttpContext.Session.SetString("Username", account.Username);
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password Wrong!");
            }
            return View();
        }

        public ActionResult UserDashboard()
        {
            if(HttpContext.Session.GetString("Username") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult AdminDashboard()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View(_context.UserAccounts.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        //public IActionResult Create()
        //{
        //    if (HttpContext.Session.GetString("Username") != null)
        //    {
        //        ViewBag.Username = HttpContext.Session.GetString("Username");
        //        return View(_context.UserAccounts.ToList());
        //    }
        //    else
        //    {
        //        return RedirectToAction("AdminDashboard");
        //    }

        //}
    }
}
