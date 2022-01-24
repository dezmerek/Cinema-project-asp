using CinemaProjectASP.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CinemaProjectASP.Controllers
{
    public class AktorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AktorController(ApplicationDbContext context)
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
