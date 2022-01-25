using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaProjectASP.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allSale = await _service.GetAllAsync();
            return View(allSale);
        }
    }
}
