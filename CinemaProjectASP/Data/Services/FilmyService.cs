using CinemaProjectASP.Data.Base;
using CinemaProjectASP.Data.ViewModels;
using CinemaProjectASP.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<NowyFilmLista> GetNewMovieDropdownsValues()
        {
            var lista = new NowyFilmLista()
            {
                Aktorzy = await _context.Aktorzy.OrderBy(n => n.ImieNazwisko).ToListAsync(),
                Sale = await _context.Sale.OrderBy(n => n.Nazwa).ToListAsync(),
                Rezyserzy = await _context.Rezyserzy.OrderBy(n => n.ImieNazwisko).ToListAsync()
            };

            return lista;
        }


    }
}
