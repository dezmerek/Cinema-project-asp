using CinemaProjectASP.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.Models
{
    public class Film
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public DateTime OdKiey { get; set; }
        public DateTime DoKiedy { get; set; }
        public FilmKategoria FilmKategoria { get; set; }
    }
}
