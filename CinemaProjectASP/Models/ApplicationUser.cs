using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name="Imie i Nazwisko")]
        public string ImieNazwisko { get; set; }
    }
}
