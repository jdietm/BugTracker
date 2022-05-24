using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlphaBugTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        private UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Users> _signInManager;

        public HomeController(ApplicationDbContext context, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Users> signInManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> GuestUser()
        {
            var user = await _userManager.FindByNameAsync("guest@gmail.com");
            await _signInManager.SignInAsync(user, isPersistent: true, authenticationMethod: "");

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}