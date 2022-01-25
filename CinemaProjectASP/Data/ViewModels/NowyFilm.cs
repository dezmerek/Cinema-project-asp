using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaProjectASP.Models
{
    public class NowyFilm
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Wprowadz dane")]
        [Display(Name = "Nazwa filmu")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Wprowadz dane")]
        [Display(Name = "Opis filmu")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Wprowadz cene")]
        [Display(Name = "Cena za bilet (xx)")]
        public double Cena { get; set; }
        [Required(ErrorMessage = "Wybierz od kiedy")]
        [Display(Name = "Od kiedy")]
        public DateTime OdKiedy { get; set; }
        [Required(ErrorMessage = "Wybierz do kiedy")]
        [Display(Name = "Do kiedy")]
        public DateTime DoKiedy { get; set; }
        [Required(ErrorMessage = "Wybierz kategorie")]
        [Display(Name = "Kategoira filmu")]
        public FilmKategoria FilmKategoria { get; set; }

        //relacja
        [Required(ErrorMessage = "Wybierz aktora")]
        [Display(Name = "Aktor")]
        public List<int> AktorIds { get; set; }
        [Required(ErrorMessage = "Wybierz sale")]
        [Display(Name = "Sala kinowa")]
        public int SalaId { get; set; }
        [Required(ErrorMessage = "Wybierz rezysera")]
        [Display(Name = "Reżyser")]
        public int RezyserId { get; set; }
    }
}
