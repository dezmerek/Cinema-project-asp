﻿using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using CinemaProjectASP.Data.Static;
using CinemaProjectASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AktorzyController : Controller
    {
        private readonly IAktorzyService _service;

        public AktorzyController(IAktorzyService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Aktorzy/Dodaj
        [Authorize(Roles = UserRoles.Admin)]
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
            await _service.AddAsync(aktor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Aktorzy/Szczegoly/1
        [AllowAnonymous]
        public async Task<IActionResult> Szczegoly(int id)
        {
            var aktorSzczegoly = await _service.GetByIdAsync(id);

            if (aktorSzczegoly == null) return View("NotFound");
            return View(aktorSzczegoly);
        }

        //Get: Aktorzy/Edytuj
        public async Task<IActionResult> Edytuj(int id)
        {
            var aktorSzczegoly = await _service.GetByIdAsync(id);
            if (aktorSzczegoly == null) return View("NotFound");
            return View(aktorSzczegoly);
        }

        [HttpPost]
        public async Task<IActionResult> Edytuj(int id, [Bind("Id, ImieNazwisko, RokUrodzenia, Biografia")] Aktor aktor)
        {
            if (!ModelState.IsValid)
            {
                return View(aktor);
            }
            await _service.UpdateAsync(id, aktor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Aktorzy/Usun/1
        public async Task<IActionResult> Usun(int id)
        {
            var aktorSzczegoly = await _service.GetByIdAsync(id);
            if (aktorSzczegoly == null) return View("NotFound");
            return View(aktorSzczegoly);
        }

        [HttpPost, ActionName("Usun")]
        public async Task<IActionResult> UsunPotwierdzenie(int id)
        {
            var aktorSzczegoly=await _service.GetByIdAsync(id);
            if (aktorSzczegoly == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
