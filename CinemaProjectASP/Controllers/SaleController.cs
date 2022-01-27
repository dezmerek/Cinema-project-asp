using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using CinemaProjectASP.Data.Static;
using CinemaProjectASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class SaleController : Controller
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allSale = await _service.GetAllAsync();
            return View(allSale);
        }

        //GET: Sale/Dodaj
        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj([Bind("Nazwa, Opis")]Sala sala)
        {
            if(!ModelState.IsValid) return View(sala);
            await _service.AddAsync(sala);
            return RedirectToAction(nameof(Index));
        }

        //GET: Sale/Szczegoly/1
        [AllowAnonymous]
        public async Task<IActionResult> Szczegoly(int id)
        {
            var salaSzczegoly = await _service.GetByIdAsync(id);
            if (salaSzczegoly == null) return View("NotFound");
            return View(salaSzczegoly);
        }

        //GET: Sale/Edytuj/1
        public async Task<IActionResult> Edytuj(int id)
        {
            var salaSzczegoly = await _service.GetByIdAsync(id);
            if (salaSzczegoly == null) return View("NotFound");
            return View(salaSzczegoly);
        }

        [HttpPost]
        public async Task<IActionResult> Edytuj(int id, [Bind("Id, Nazwa, Opis")] Sala sala)
        {
            if (!ModelState.IsValid) return View(sala);
            await _service.UpdateAsync(id, sala);
            return RedirectToAction(nameof(Index));
        }

        //GET: Sale/Usun/1
        public async Task<IActionResult> Usun(int id)
        {
            var salaSzczegoly = await _service.GetByIdAsync(id);
            if (salaSzczegoly == null) return View("NotFound");
            return View(salaSzczegoly);
        }

        [HttpPost, ActionName("Usun")]
        public async Task<IActionResult> UsunPotwierdzenie(int id)
        {
            var salaSzczegoly = await _service.GetByIdAsync(id);
            if (salaSzczegoly == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
