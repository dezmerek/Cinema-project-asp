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

        public void Add(Aktor aktor)
        {
            _context.Aktorzy.Add(aktor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Aktor>> GetAll()
        {
            var result = await _context.Aktorzy.ToListAsync();
            return result;
        }

        public Aktor GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Aktor Update(int id, Aktor newAktor)
        {
            throw new System.NotImplementedException();
        }
    }
}
