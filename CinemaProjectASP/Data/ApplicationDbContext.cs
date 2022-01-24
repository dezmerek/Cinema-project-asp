using CinemaProjectASP.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaProjectASP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aktor_Film>().HasKey(am => new
            {
                am.AktorId,
                am.FilmId
            });

            modelBuilder.Entity<Aktor_Film>().HasOne(m => m.Film).WithMany(am => am.Aktors_Films).HasForeignKey(m => m.FilmId);
            modelBuilder.Entity<Aktor_Film>().HasOne(m => m.Aktor).WithMany(am => am.Aktors_Films).HasForeignKey(m => m.AktorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Aktor> Aktors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Aktor_Film> Aktors_Films { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Rezyser> Rezysers { get; set; }

    }
}
