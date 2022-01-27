using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Static;
using CinemaProjectASP.Models;
using CinemaProjectASP.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Uzytkownicy()
        {
            var uzytkownicy = await _context.Users.ToListAsync();
            return View(uzytkownicy);
        }

        public IActionResult Login() => View(new Login());

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid) return View(login);

            var user = await _userManager.FindByEmailAsync(login.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, login.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Filmy");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(login);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(login);
        }

        public IActionResult Rejestracja() => View(new Rejestracja());

        [HttpPost]
        public async Task<IActionResult> Rejestracja(Rejestracja rejestracja)
        {
            if (!ModelState.IsValid) return View(rejestracja);

            var user = await _userManager.FindByEmailAsync(rejestracja.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Ten adres e-mail jest już w użyciu";
                return View(rejestracja);
            }

            var newUser = new ApplicationUser()
            {
                FullName = rejestracja.FullName,
                Email = rejestracja.EmailAddress,
                UserName = rejestracja.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, rejestracja.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RejestracjaZakonczona");
        }

        [HttpPost]
        public async Task<IActionResult> Wyloguj()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Filmy");
        }
    }
}