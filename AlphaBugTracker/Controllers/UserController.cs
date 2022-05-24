using AlphaBugTracker.BLL;
using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlphaBugTracker.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly UserBusinessLogic _userBLL;
        private readonly SignInManager<Users> _signInManager;

        public UserController(UserManager<Users> userManager, IRepository<Users> repoArg, SignInManager<Users> signInManager)
        {
            _signInManager = signInManager;
            _userBLL = new UserBusinessLogic(repoArg);
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(string userName, string passwordHash)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (userName is not null && userName != "")
            {
                user.UserName = userName;
                user.NormalizedUserName = userName.ToUpper();
            }

            if (passwordHash is not null && passwordHash != "")
            {
                var passwordHasher = new PasswordHasher<Users>();
                var hashed = passwordHasher.HashPassword(user, passwordHash);
                user.PasswordHash = hashed;
            }


            _userBLL.UpdateNameAndPassword(user);
            await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
