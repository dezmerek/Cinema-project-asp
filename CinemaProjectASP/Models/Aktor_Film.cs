namespace CinemaProjectASP.Models
{
    public class Aktor_Film
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int AktorId { get; set; }
        public Aktor Aktor { get; set; }
    }
}
