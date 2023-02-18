using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.EfDbContext;
using WebApi.Entities;

namespace Tests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this DbContextBooksStore context)
        {
            context.Genres.AddRange(
            new Genre{Name = "Roman"},
            new Genre{Name = "Aksiyon"},
            new Genre{Name = "Bilim Kurgu"});
        }
    }
}
