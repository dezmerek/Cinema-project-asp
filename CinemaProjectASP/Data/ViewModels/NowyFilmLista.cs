using CinemaProjectASP.Models;
using System.Collections.Generic;

namespace CinemaProjectASP.Data.ViewModels
{
    public class NowyFilmLista
    {
        public NowyFilmLista()
        {
            Rezyserzy=new List<Rezyser>();
            Sale=new List<Sala>();
            Aktorzy = new List<Aktor>();

        }

        public List<Rezyser> Rezyserzy { get; set; }
        public List<Sala> Sale { get; set; }
        public List<Aktor> Aktorzy { get; set; }
    }
}
