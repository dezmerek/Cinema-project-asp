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

        public async Task DodajNowyFilmAsync(NowyFilm dane)
        {
            var nowyFilm = new Film()
            {
                Nazwa = dane.Nazwa,
                Opis = dane.Opis,
                Cena = dane.Cena,
                SalaId = dane.SalaId,
                OdKiedy = dane.OdKiedy,
                DoKiedy = dane.DoKiedy,
                FilmKategoria = dane.FilmKategoria,
                RezyserId = dane.RezyserId
            };
            await _context.Filmy.AddAsync(nowyFilm);
            await _context.SaveChangesAsync();

            //Dodanie do filmu aktora
            foreach (var AktorId in dane.AktorIds)
            {
                var nowyAktorFilm = new Aktor_Film()
                {
                    FilmId = nowyFilm.Id,
                    AktorId = AktorId
                };
                await _context.Aktorzy_Filmy.AddAsync(nowyAktorFilm);
            }
            await _context.SaveChangesAsync();
        }

        public async Task EdytujNowyFilmAsync(NowyFilm dane)
        {
            var dbFilm = await _context.Filmy.FirstOrDefaultAsync(n => n.Id == dane.Id);

            if(dbFilm != null)
            {
                dbFilm.Nazwa = dane.Nazwa;
                dbFilm.Opis = dane.Opis;
                dbFilm.Cena = dane.Cena;
                dbFilm.SalaId = dane.SalaId;
                dbFilm.OdKiedy = dane.OdKiedy;
                dbFilm.DoKiedy = dane.DoKiedy;
                dbFilm.FilmKategoria = dane.FilmKategoria;
                dbFilm.RezyserId = dane.RezyserId;
                await _context.SaveChangesAsync();
            }

            //Usuwanie utworzonego autora
            var utworzonyAktorDb=_context.Aktorzy_Filmy.Where(n=>n.FilmId == dane.Id).ToList();
            _context.Aktorzy_Filmy.RemoveRange(utworzonyAktorDb);
            await _context.SaveChangesAsync();

            //Dodanie do filmu aktora
            foreach (var AktorId in dane.AktorIds)
            {
                var nowyAktorFilm = new Aktor_Film()
                {
                    FilmId = dane.Id,
                    AktorId = AktorId
                };
                await _context.Aktorzy_Filmy.AddAsync(nowyAktorFilm);
            }
            await _context.SaveChangesAsync();
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
