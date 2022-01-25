using CinemaProjectASP.Models;
using CinemaProjectASP.Data.Base;
using System.Threading.Tasks;

namespace CinemaProjectASP.Data.Services
{
    public interface IFilmyService:IEntityBaseRepository<Film>
    {
        Task<Film> GetMovieByIdAsync(int id);
    }
}
