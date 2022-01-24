using CinemaProjectASP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            var allFilmy = await _context.Filmy.Include(n=>n.Sala).OrderByDescending(n=>n.DoKiedy).ToListAsync();
            return View(allFilmy);
        }
    }
}
