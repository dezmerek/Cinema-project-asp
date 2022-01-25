using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.ViewModels
{
    public class Rejestracja
    {
        [Display(Name = "Imie i Nazwisko")]
        [Required(ErrorMessage = "Imie i Nazwisko jest wymagane")]
        public string FullName { get; set; }

        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Powtórz hasło")]
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła do siebie nie pasują")]
        public string ConfirmPassword { get; set; }
    }
}