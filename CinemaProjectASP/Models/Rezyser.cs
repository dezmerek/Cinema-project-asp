using CinemaProjectASP.Data.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.Models
{
    public class Rezyser : IEntityBase
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Imie i Nazwisko")]
        [Required(ErrorMessage = "Wprowadz dane")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Od 3 do 50 znaków")]
        public string ImieNazwisko { get; set; }
        [Display(Name = "Rok urodzenia")]
        [Required(ErrorMessage = "Wprowadz dane")]
        [Range(minimum: 1800, maximum: 2030, ErrorMessage = "Podaj rok między 1800 a 2030")]
        public int RokUrodzenia { get; set; }
        [Required(ErrorMessage = "Wprowadz dane")]
        [Display(Name = "Biografia")]
        public string Biografia { get; set; }

        //relacja
        public List<Film> Filmy { get; set; }
    }
}
