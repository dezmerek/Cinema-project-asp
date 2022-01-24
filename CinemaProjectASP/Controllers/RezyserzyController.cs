using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
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
    }
}
