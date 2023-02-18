using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi.Entities;

namespace WebApi.EfDbContext
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DbContextBooksStore(serviceProvider.GetRequiredService<DbContextOptions<DbContextBooksStore>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Dan Brown",
                        Birthday = new DateTime(1964, 06, 22),

                    },
                    new Author
                    {
                        Name = "Frank Herbert",
                        Birthday = new DateTime(1920, 10, 08),
                    },
                    new Author
                    {
                        Name = "Nazım Hikmet",
                        Birthday = new DateTime(1902, 01, 15),
                    });                

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Roman",
                        

                    },
                    new Genre
                    {
                        Name = "Aksiyon"

                    },
                    new Genre
                    {
                        Name = "Bilim Kurgu"

                    });

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
                
                context.SaveChanges();

            }
        }
    }
}
