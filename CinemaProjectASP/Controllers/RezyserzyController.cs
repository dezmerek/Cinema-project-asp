using CinemaProjectASP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    public class RezyserzyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezyserzyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allRezyserzy = await _context.Rezyserzy.ToListAsync();
            return View();
        }
    }
}
