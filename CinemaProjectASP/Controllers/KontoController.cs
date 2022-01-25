using CinemaProjectASP.Data;
using CinemaProjectASP.Models;
using CinemaProjectASP.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

    }
}