using CinemaProjectASP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    public class FilmyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allFilmy = await _context.Filmy.ToListAsync();
            return View();
        }
    }
}
