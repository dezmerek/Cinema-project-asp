using CinemaProjectASP.Data.Base;
using CinemaProjectASP.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaProjectASP.Data.Services
{
    public class FilmyService : EntityBaseRepository<Film>, IFilmyService
    {
        private readonly ApplicationDbContext _context;
        public FilmyService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Film> GetMovieByIdAsync(int id)
        {
            var filmSzczegoly = await _context.Filmy
                .Include(c => c.Sala)
                .Include(p => p.Rezyser)
                .Include(am => am.Aktorzy_Filmy).ThenInclude(a => a.Aktor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return filmSzczegoly;
        }
    }
}
