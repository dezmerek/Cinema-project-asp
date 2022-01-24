using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    public class AktorzyController : Controller
    {
        private readonly IAktorzyService _service;

        public AktorzyController(IAktorzyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        //Get: Aktorzy/Dodaj
        public IActionResult Dodaj()
        {
            return View();
        }
    }
}
