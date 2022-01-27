using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using CinemaProjectASP.Data.Static;
using CinemaProjectASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class FilmyController : Controller
    {
        private readonly IFilmyService _service;

        public FilmyController(IFilmyService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allFilmy = await _service.GetAllAsync(n=>n.Sala);
            return View(allFilmy);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filtr(string szukanaFraza)
        {
            var wszystkieFilmy = await _service.GetAllAsync(n => n.Sala);

            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                var filteredResult = wszystkieFilmy.Where(n => n.Nazwa.Contains(szukanaFraza) || n.Opis.Contains(szukanaFraza)).ToList();
                return View("Index",filteredResult);
            }

            return View("Index", wszystkieFilmy);
        }

        //GET: Filmy/Szczegoly/1
        [AllowAnonymous]
        public async Task<IActionResult> Szczegoly(int id)
        {
            var filmSzczegoly = await _service.GetMovieByIdAsync(id);
            return View(filmSzczegoly);
        }

        //GET: Filmy/Dodaj
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

        //GET: Filmy/Edytuj/1
        public async Task<IActionResult> Edytuj(int id)
        {
            var filmSzczegoly = await _service.GetMovieByIdAsync(id);
            if (filmSzczegoly == null) return View("NotFound");

            var response = new NowyFilm()
            {
                Id = filmSzczegoly.Id,
                Nazwa = filmSzczegoly.Nazwa,
                Opis = filmSzczegoly.Opis,
                Cena = filmSzczegoly.Cena,
                OdKiedy = filmSzczegoly.OdKiedy,
                DoKiedy = filmSzczegoly.DoKiedy,
                FilmKategoria= filmSzczegoly.FilmKategoria,
                SalaId = filmSzczegoly.SalaId,
                RezyserId = filmSzczegoly.RezyserId,
                AktorIds = filmSzczegoly.Aktorzy_Filmy.Select(n => n.AktorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Sale = new SelectList(movieDropdownsData.Sale, "Id", "Nazwa");
            ViewBag.Rezyserzy = new SelectList(movieDropdownsData.Rezyserzy, "Id", "ImieNazwisko");
            ViewBag.Aktorzy = new SelectList(movieDropdownsData.Aktorzy, "Id", "ImieNazwisko");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edytuj(int id, NowyFilm film)
        {
            if (id != film.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Sale = new SelectList(movieDropdownsData.Sale, "Id", "Nazwa");
                ViewBag.Rezyserzy = new SelectList(movieDropdownsData.Rezyserzy, "Id", "ImieNazwisko");
                ViewBag.Aktorzy = new SelectList(movieDropdownsData.Aktorzy, "Id", "ImieNazwisko");

                return View(film);
            }

            await _service.EdytujNowyFilmAsync(film);
            return RedirectToAction(nameof(Index));
        }
    }
}
