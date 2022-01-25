using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaProjectASP.Models
{
    public class ZamowieniePrzedmiot
    {
        [Key]
        public int Id { get; set; }
        public string Ilosc { get; set; }
        public string Cena { get; set; }   

        public int FilmId { get; set; }
        [ForeignKey("FilmId")]
        public Film Film { get; set; }

        public int ZamowienieId { get; set; }
        [ForeignKey("ZamowienieId")]
        public Zamowienie Zamowienie { get; set; }
    }
}
