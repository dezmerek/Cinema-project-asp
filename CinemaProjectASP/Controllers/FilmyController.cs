using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using CinemaProjectASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    public class FilmyController : Controller
    {
        private readonly IFilmyService _service;

        public FilmyController(IFilmyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allFilmy = await _service.GetAllAsync(n=>n.Sala);
            return View(allFilmy);
        }

        //GET: Filmy/Szczegoly/1
        public async Task<IActionResult> Szczegoly(int id)
        {
            var filmSzczegoly = await _service.GetMovieByIdAsync(id);
            return View(filmSzczegoly);
        }

        //GET: Filmy/Create
        public async Task<IActionResult> Dodaj()
        {
            var filmDane = await _service.GetNewMovieDropdownsValues();

            ViewBag.Sale = new SelectList(filmDane.Sale, "Id","Nazwa");
            ViewBag.Rezyserzy = new SelectList(filmDane.Rezyserzy, "Id","ImieNazwisko");
            ViewBag.Aktorzy = new SelectList(filmDane.Aktorzy, "Id","ImieNazwisko");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj(NowyFilm film)
        {
            if(!ModelState.IsValid)
            {
                var filmDane = await _service.GetNewMovieDropdownsValues();

                ViewBag.Sale = new SelectList(filmDane.Sale, "Id", "Nazwa");
                ViewBag.Rezyserzy = new SelectList(filmDane.Rezyserzy, "Id", "ImieNazwisko");
                ViewBag.Aktorzy = new SelectList(filmDane.Aktorzy, "Id", "ImieNazwisko");

                return View(film);
            }

            await _service.DodajNowyFilmAsync(film);
            return RedirectToAction(nameof(Index));
        }
    }
}
