using CinemaProjectASP.Data.Base;
using CinemaProjectASP.Models;

namespace CinemaProjectASP.Data.Services
{
    public class SaleService : EntityBaseRepository<Sala>, ISaleService
    {
        public SaleService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
