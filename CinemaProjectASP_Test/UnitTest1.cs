using System;
using Xunit;
using CinemaProjectASP.Models;
using CinemaProjectASP.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CinemaProjectASP.Data.Base;

namespace CinemaProjectASP
{
    public class UnitTest1
    {
        [Fact]
        public void GetFilmTest()
        {
            EntityBaseRepository repository = new EntityBaseRepository();
            repository.AddAsync(new Film() { Nazwa = "TEST" });
            repository.AddAsync(new Film() { Opis = "TEST" });
            ApiAktorzyController controllerTest = new ApiAktorzyController(repository);
            IList<Film> filmy = controllerTest.nowyFilm();
            Assert.Equal(2, filmy.Count);
        }
        [Fact]
        public void AddFilmTest()
        {
            EntityBaseRepository repository = new EntityBaseRepository();
            repository.AddAsync(new Film() { Nazwa = "TEST" });
            repository.AddAsync(new Film() { Opis = "TEST" });
            ApiAktorzyController controllerTest = new ApiAktorzyController(repository);
            Film newFilm = new Film() {Id = 50, Nazwa = "NEW" };
            ActionResult<Film> actionResult = controllerTest.nowyFilm(nowyFilm);
            Assert.Equal("NEW", repository.FindFilm(3).Name);
        }
        [Fact]
        public void FindFilmId()
        {
            EntityBaseRepository repository = new EntityBaseRepository();
            repository.AddAsync(new Film() { Id = 40, Nazwa = "TEST" });
            repository.AddAsync(new Film() { Opis = "TEST" });
            ApiAktorzyController controllerTest = new ApiAktorzyController(repository);
            var test = repository.FindFilm(1);
            Assert.Equal("TEST", test.Name);
        }
    }
}
