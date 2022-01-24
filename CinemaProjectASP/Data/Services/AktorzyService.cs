using CinemaProjectASP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Data.Services
{
    public class AktorzyService : IAktorzyService
    {
        private readonly ApplicationDbContext _context;
        public AktorzyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Aktor aktor)
        {
            await _context.Aktorzy.AddAsync(aktor);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Aktor>> GetAllAsync()
        {
            var result = await _context.Aktorzy.ToListAsync();
            return result;
        }

        public async Task<Aktor> GetByIdAsync(int id)
        {
            var result = await _context.Aktorzy.FirstOrDefaultAsync(n=>n.Id==id);
            return result;
        }

        public Aktor Update(int id, Aktor newAktor)
        {
            throw new System.NotImplementedException();
        }
    }
}
