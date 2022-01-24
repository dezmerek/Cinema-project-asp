using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using CinemaProjectASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    public class AktorzyController : Controller
    {
        private readonly IAktorzyService _service;

        public AktorzyController(IAktorzyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        //Get: Aktorzy/Dodaj
        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj([Bind("ImieNazwisko, RokUrodzenia, Biografia")] Aktor aktor)
        {
            if (!ModelState.IsValid)
            {
                return View(aktor);
            }
            _service.Add(aktor);
            return RedirectToAction(nameof(Index));
        }
    }
}
