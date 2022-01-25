using CinemaProjectASP.Data.Base;
using CinemaProjectASP.Data;
using CinemaProjectASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Data.Services
{
    public class RezyserzyService : EntityBaseRepository<Rezyser>, IRezyserzyService
    {
        public RezyserzyService(ApplicationDbContext context) : base(context)
        {
        }
    }
}