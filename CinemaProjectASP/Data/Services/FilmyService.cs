using CinemaProjectASP.Data.Base;
using CinemaProjectASP.Models;

namespace CinemaProjectASP.Data.Services
{
    public class FilmyService : EntityBaseRepository<Film>, IFilmyService
    {
        public FilmyService(ApplicationDbContext context):base(context)
        {

        }
    }
}
