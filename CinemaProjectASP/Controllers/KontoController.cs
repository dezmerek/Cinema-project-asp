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
    public class KontoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public KontoController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
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

        public IActionResult Logowanie() => View(new Logowanie());

        [HttpPost]
        public async Task<IActionResult> Logowanie(Logowanie logowanie)
        {
            if (!ModelState.IsValid) return View(logowanie);

            var user = await _userManager.FindByEmailAsync(logowanie.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, logowanie.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, logowanie.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Filmy");
                    }
                }
                TempData["Error"] = "Błędne dane. Proszę spróbuj ponownie";
                return View(logowanie);
            }

            TempData["Error"] = "Błędne dane. Proszę spróbuj ponownie";
            return View(logowanie);
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