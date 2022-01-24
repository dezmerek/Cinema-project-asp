using CinemaProjectASP.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //relacja
        public List<Aktor_Film> Aktors_Films { get; set; }

        //sala
        public int SalaId { get; set; }
        [ForeignKey("SalaId")]
        public Sala Sala { get; set; }

        //Rezyser
        public int RezyserId { get; set; }
        [ForeignKey("RezyserId")]
        public Rezyser Rezyser { get; set; }
    }
}
