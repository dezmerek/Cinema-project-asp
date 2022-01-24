﻿using CinemaProjectASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProjectASP.Data.Services
{
    public interface IAktorzyService
    {
        Task<IEnumerable<Aktor>> GetAll();
        Aktor GetById(int id);
        void Add(Aktor aktor);
        Aktor Update(int id, Aktor newAktor);
        void Delete(int id);
    }
}
