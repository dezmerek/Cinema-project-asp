using CinemaProjectASP.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CinemaProjectASP.Controllers
{
    public class AktorzyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AktorzyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Aktorzy.ToList();
            return View();
        }
    }
}
