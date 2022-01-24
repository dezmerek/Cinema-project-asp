using CinemaProjectASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProjectASP.Data.Services
{
    public interface IAktorzyService
    {
        Task<IEnumerable<Aktor>> GetAllAsync();
        Task<Aktor> GetByIdAsync(int id);
        Task AddAsync(Aktor aktor);
        Aktor Update(int id, Aktor newAktor);
        void Delete(int id);
    }
}
