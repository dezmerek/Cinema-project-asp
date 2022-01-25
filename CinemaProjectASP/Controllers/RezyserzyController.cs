using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using CinemaProjectASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    public class RezyserzyController : Controller
    {
        private readonly IRezyserzyService _service;

        public RezyserzyController(IRezyserzyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allRezyserzy = await _service.GetAllAsync();
            return View(allRezyserzy);
        }

        //GET: Rezyserzy/Szczegoly/1
        public async Task<IActionResult> Szczegoly(int id)
        {
            var rezyserSzczegoly = await _service.GetByIdAsync(id);
            if (rezyserSzczegoly == null) return View("NotFound");
            return View(rezyserSzczegoly);
        }

        //GET: Rezyserzy/Dodaj
        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj([Bind("ImieNazwisko, RokUrodzenia, Biografia")]Rezyser rezyser)
        {
            if(!ModelState.IsValid) return View(rezyser);

            await _service.AddAsync(rezyser);
            return RedirectToAction(nameof(Index));
        }

        //GET: Rezyserzy/Edytuj/1
        public async Task<IActionResult> Edytuj(int id)
        {
            var rezyserzySzczegoly=await _service.GetByIdAsync(id);
            if(rezyserzySzczegoly==null) return View("NotFound");
            return View(rezyserzySzczegoly);
        }

        [HttpPost]
        public async Task<IActionResult> Edytuj(int id, [Bind("Id, ImieNazwisko, RokUrodzenia, Biografia")] Rezyser rezyser)
        {
            if (!ModelState.IsValid) return View(rezyser);

            if(id==rezyser.Id)
            {
                await _service.UpdateAsync(id, rezyser);
                return RedirectToAction(nameof(Index));
            }
            return View(rezyser);
        }

        //GET: Rezyserzy/Usun/1
        public async Task<IActionResult> Usun(int id)
        {
            var rezyserzyUsun = await _service.GetByIdAsync(id);
            if (rezyserzyUsun == null) return View("NotFound");
            return View(rezyserzyUsun);
        }

        [HttpPost, ActionName("Usun")]
        public async Task<IActionResult> UsunPotwierdzenie(int id)
        {
            var rezyserzyUsun = await _service.GetByIdAsync(id);
            if (rezyserzyUsun == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
