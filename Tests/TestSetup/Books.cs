using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.EfDbContext;
using WebApi.Entities;

namespace Tests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this DbContextBooksStore context)
        {
            context.Books.AddRange(
            new Book
            {

                Title = "Dijital Kale",
                GenreId = 3,
                PageCount = 400,
                PublisDate = new DateTime(2022, 07, 07),
                AuthorId = 1,
                IsPublished = true

            },
            new Book
            {

                Title = "Dune",
                GenreId = 2,
                PageCount = 250,
                PublisDate = new DateTime(2012, 08, 23),
                AuthorId = 2,
                IsPublished = true

            },
            new Book
            {

                Title = "Nâzım ile Piraye",
                GenreId = 1,
                PageCount = 489,
                PublisDate = new DateTime(2002, 10, 01),
                AuthorId = 3,
                IsPublished = true

            });
        }
    }
}
