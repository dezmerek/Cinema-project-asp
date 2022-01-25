using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using CinemaProjectASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService service)
        {
            _service = service;
        }

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
    }
}
