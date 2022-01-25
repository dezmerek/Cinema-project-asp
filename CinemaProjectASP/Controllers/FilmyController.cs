using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using Microsoft.AspNetCore.Mvc;
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
    }
}
