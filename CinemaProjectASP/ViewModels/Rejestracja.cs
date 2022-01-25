using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.ViewModels
{
    public class Rejestracja
    {
        [Display(Name = "Imie i Nazwisko")]
        [Required(ErrorMessage = "Imie i Nazwisko jest wymagane")]
        public string FullName { get; set; }

        [Display(Name = "Adres e-mail")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Niepoprawny adres email! ")]
        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        public string EmailAddress { get; set; }

        [Display(Name = "Hasło (minimum 6 znaków, 1 duża, 1 mała, 1 liczba, 1 znak specjalny)")]
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