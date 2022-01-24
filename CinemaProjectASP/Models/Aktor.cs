using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.Models
{
    public class Aktor
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        public string ImieNazwisko { get; set; }
        public int RokUrodzenia { get; set; }
        public string Biografia { get; set; }

        //relacja
        public List<Aktor_Film> Aktorzy_Filmy { get; set; }
    }
}
