using CinemaProjectASP.Models;
using CinemaProjectASP.Data.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Data.Services
{
    public class AktorzyService : EntityBaseRepository<Aktor>, IAktorzyService
    {
        public AktorzyService(ApplicationDbContext context) : base(context) { }
    }
}
