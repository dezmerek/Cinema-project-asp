using CinemaProjectASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaProjectASP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

            modelBuilder.Entity<Aktor_Film>().HasOne(m => m.Film).WithMany(am => am.Aktorzy_Filmy).HasForeignKey(m => m.FilmId);
            modelBuilder.Entity<Aktor_Film>().HasOne(m => m.Aktor).WithMany(am => am.Aktorzy_Filmy).HasForeignKey(m => m.AktorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Aktor> Aktorzy { get; set; }
        public DbSet<Film> Filmy { get; set; }
        public DbSet<Aktor_Film> Aktorzy_Filmy { get; set; }
        public DbSet<Sala> Sale { get; set; }
        public DbSet<Rezyser> Rezyserzy { get; set; }

    }
}
