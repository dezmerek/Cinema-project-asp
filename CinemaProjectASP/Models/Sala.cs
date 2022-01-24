using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.Models
{
    public class Sala
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }
        [Display(Name = "Opis")]
        public string Opis { get; set; }

        //relacja
        public List<Film> Filmy { get; set; }
    }
}
