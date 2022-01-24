using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.Models
{
    public class Rezyser
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Imie i Nazwisko")]
        public string ImieNazwisko { get; set; }
        [Display(Name = "Rok urodzenia")]
        public int RokUrodzenia { get; set; }
        [Display(Name = "Biografia")]
        public string Biografia { get; set; }

        //relacja
        public List<Film> Filmy { get; set; }
    }
}
