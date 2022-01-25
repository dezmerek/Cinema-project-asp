using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaProjectASP.Models
{
    public class Zamowienie
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }

        public List<ZamowieniePrzedmiot> ZamowienionePrzedmioty { get; set; } 
    }
}
