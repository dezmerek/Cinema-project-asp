using CinemaProjectASP.Data.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.Models
{
    public class Sala : IEntityBase
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Wprowadz dane")]
        public string Nazwa { get; set; }
        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Wprowadz dane")]
        public string Opis { get; set; }

        //relacja
        public List<Film> Filmy { get; set; }
    }
}
