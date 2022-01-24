﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.Models
{
    public class Rezyser
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        public string ImieNazwisko { get; set; }
        public int RokUrodzenia { get; set; }
        public string Biografia { get; set; }
    }
}
