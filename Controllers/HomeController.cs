using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DojoTactics.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DojoTactics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;
        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    //========================================
    //                  Register
    //========================================

        [HttpGet("Registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Registration");
                } 
                    
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    _context.Add(newUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("LoggedinUser", newUser.UserId);
                    return RedirectToAction("Profile");
                }
                else
                {
                    return View("Registration");
                }
        }

    //========================================
    //                  Login
    //========================================

        [HttpPost("Login")]
        public IActionResult Login(LoginUser userSubmission)
        {
                if(ModelState.IsValid)
                {
                    var userInDb = _context.Users.FirstOrDefault(u => u.Username == userSubmission.LUsername);
                    if(userInDb == null)
                    {
                        ModelState.AddModelError("LUsername", "Invalid Username/Password");
                        return View("Index");
                    }
                    var hasher = new PasswordHasher<LoginUser>();
                    var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LPassword);
                    if(result == 0)
                    {
                        ModelState.AddModelError("LPassword", "Invalid Email/Password");
                        return View("Index");
                    }
                    HttpContext.Session.SetInt32("LoggedinUser", userInDb.UserId);
                    return RedirectToAction("Profile");
                }
                return View("Index");
        }

    //========================================
    //                  Profile
    //========================================

    
    [HttpGet("Profile")]
    public IActionResult Profile()
    {
        ViewBag.ActiveUser = _context.Users.FirstOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("LoggedinUser"));
        ViewBag.UserFriends = _context.Friends
            .Include(u => u.FriendUser)
            .Where(u => u.UserId == (int)HttpContext.Session.GetInt32("LoggedinUser"));
        return View();
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
