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

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Aktorzy.FirstOrDefaultAsync(n => n.Id == id);
            _context.Aktorzy.Remove(result);
            await _context.SaveChangesAsync();
        }



        public async Task<Aktor> UpdateAsync(int id, Aktor nowyAktor)
        {
            _context.Update(nowyAktor);
            await _context.SaveChangesAsync();
            return nowyAktor;
        }
    }
}
