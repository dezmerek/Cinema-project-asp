using CinemaProjectASP.Data;
using CinemaProjectASP.Data.Static;
using CinemaProjectASP.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProjectASP.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //sala
                if (!context.Sale.Any())
                {
                    context.Sale.AddRange(new List<Sala>()
                    {
                    new Sala()
                    {
                        Nazwa = "Merkury",
                        Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt."
                    },
                    new Sala()
                    {
                        Nazwa = "Wenus",
                        Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt."
                    },
                    new Sala()
                    {
                        Nazwa = "Ziemia",
                        Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt."
                    },
                    new Sala()
                    {
                        Nazwa = "Mars",
                        Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt."
                    },
                    new Sala()
                    {
                        Nazwa = "Jowisz",
                        Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt."
                    },
                    });
                    context.SaveChanges();
                }

                //aktorzy
                if (!context.Aktorzy.Any())
                {
                    context.Aktorzy.AddRange(new List<Aktor>()
                    {
                    new Aktor()
                    {
                        ImieNazwisko = "Mark Wahlberg",
                        RokUrodzenia = 1971,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    new Aktor()
                    {
                        ImieNazwisko = "Salma Hayek",
                        RokUrodzenia = 1966,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    new Aktor()
                    {
                        ImieNazwisko = "Antonio Banderas",
                        RokUrodzenia = 1960,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    new Aktor()
                    {
                        ImieNazwisko = "Sophia Ali",
                        RokUrodzenia = 1995,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    new Aktor()
                    {
                        ImieNazwisko = "Tom Holland",
                        RokUrodzenia = 1996,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    });
                    context.SaveChanges();
                }

                //rezyserowie
                if (!context.Rezyserzy.Any())
                {
                    context.Rezyserzy.AddRange(new List<Rezyser>()
                    {
                    new Rezyser()
                    {
                        ImieNazwisko = "Ruben Fleischer",
                        RokUrodzenia = 1974,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    new Rezyser()
                    {
                        ImieNazwisko = "Joachim Trier",
                        RokUrodzenia = 1974,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    new Rezyser()
                    {
                        ImieNazwisko = "Matt Reeves",
                        RokUrodzenia = 1966,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    new Rezyser()
                    {
                        ImieNazwisko = "Paloma Baeza",
                        RokUrodzenia = 1975,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    new Rezyser()
                    {
                        ImieNazwisko = "Matt Bettinelli-Olpin",
                        RokUrodzenia = 1978,
                        Biografia = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non pulvinar augue, a dignissim leo. Cras eu neque id turpis lobortis euismod. Donec eros velit, imperdiet et venenatis eget, consectetur imperdiet est. Aenean nec tempor augue. Proin in pretium odio. Cras tempor luctus lorem. Proin faucibus dictum erat, sit amet finibus lorem vehicula nec. Morbi ultricies elit quis interdum faucibus.",
                    },
                    });
                    context.SaveChanges();
                }

                //filmy
                if (!context.Filmy.Any())
                {
                    context.Filmy.AddRange(new List<Film>()
                    {
                        new Film()
                        {
                            Nazwa = "Anioły w Ameryce",
                            Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt.",
                            Cena = 19,
                            OdKiedy  = DateTime.Now.AddDays(-10),
                            DoKiedy = DateTime.Now,
                            SalaId = 3,
                            RezyserId = 3,
                            FilmKategoria = FilmKategoria.Akcja
                        },
                        new Film()
                        {
                            Nazwa = "Fargo",
                            Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt.",
                            Cena = 19,
                            OdKiedy  = DateTime.Now,
                            DoKiedy = DateTime.Now.AddDays(3),
                            SalaId = 1,
                            RezyserId = 1,
                            FilmKategoria = FilmKategoria.Akcja
                        },
                        new Film()
                        {
                            Nazwa = "Moonfall",
                            Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt.",
                            Cena = 19,
                            OdKiedy  = DateTime.Now,
                            DoKiedy = DateTime.Now.AddDays(7),
                            SalaId = 4,
                            RezyserId = 4,
                            FilmKategoria = FilmKategoria.Akcja
                        },
                        new Film()
                        {
                            Nazwa = "Ból i blask",
                            Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt.",
                            Cena = 19,
                            OdKiedy  = DateTime.Now.AddDays(-10),
                            DoKiedy = DateTime.Now.AddDays(-5),
                            SalaId = 1,
                            RezyserId = 2,
                            FilmKategoria = FilmKategoria.Akcja
                        },
                        new Film()
                        {
                            Nazwa = "Maska Zorro",
                            Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt.",
                            Cena = 19,
                            OdKiedy  = DateTime.Now.AddDays(-10),
                            DoKiedy = DateTime.Now.AddDays(-2),
                            SalaId = 5,
                            RezyserId = 3,
                            FilmKategoria = FilmKategoria.Akcja
                        },
                        new Film()
                        {
                            Nazwa = "Desperado",
                            Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam efficitur risus non orci volutpat aliquam. Cras nec porttitor sem. Praesent in aliquet est, quis tincidunt.",
                            Cena = 19,
                            OdKiedy  = DateTime.Now.AddDays(3),
                            DoKiedy = DateTime.Now.AddDays(20),
                            SalaId = 2,
                            RezyserId = 5,
                            FilmKategoria = FilmKategoria.Akcja
                        },
                    });
                    context.SaveChanges();
                }

                //aktorzy & filmy
                if (!context.Aktorzy_Filmy.Any())
                {
                    context.Aktorzy_Filmy.AddRange(new List<Aktor_Film>()
                   {
                        new Aktor_Film()
                        {
                            AktorId = 1,
                            FilmId = 1
                        },
                        new Aktor_Film()
                        {
                            AktorId = 3,
                            FilmId = 1
                        },

                        new Aktor_Film()
                        {
                            AktorId = 1,
                            FilmId = 2
                        },
                        new Aktor_Film()
                        {
                            AktorId = 4,
                            FilmId = 2
                        },

                        new Aktor_Film()
                        {
                            AktorId = 1,
                            FilmId = 3
                        },
                        new Aktor_Film()
                        {
                            AktorId = 2,
                            FilmId = 3
                        },
                        new Aktor_Film()
                        {
                            AktorId = 5,
                            FilmId = 3
                        },


                        new Aktor_Film()
                        {
                            AktorId = 2,
                            FilmId = 4
                        },
                        new Aktor_Film()
                        {
                            AktorId = 3,
                            FilmId = 4
                        },
                        new Aktor_Film()
                        {
                            AktorId = 4,
                            FilmId = 4
                        },


                        new Aktor_Film()
                        {
                            AktorId = 2,
                            FilmId = 5
                        },
                        new Aktor_Film()
                        {
                            AktorId = 3,
                            FilmId = 5
                        },
                        new Aktor_Film()
                        {
                            AktorId = 4,
                            FilmId = 5
                        },
                        new Aktor_Film()
                        {
                            AktorId = 5,
                            FilmId = 5
                        },


                        new Aktor_Film()
                        {
                            AktorId = 3,
                            FilmId = 6
                        },
                        new Aktor_Film()
                        {
                            AktorId = 4,
                            FilmId = 6
                        },
                        new Aktor_Film()
                        {
                            AktorId = 5,
                            FilmId = 6
                        },
                        });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@cinema.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@cinema.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Admin@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}