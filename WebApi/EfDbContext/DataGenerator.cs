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
                       Name = "Dan",
                       lastName = "Brow",
                       Birth = new DateTime(),
                       BookId = 1
                   },
                   new Author
                   {
                       Name = "Frank",
                       lastName = "Herbert",
                       Birth = new DateTime(),
                       BookId = 2

                   },
                   new Author
                   {
                       Name = "Nazım",
                       lastName = "Hikmet",
                       Birth = new DateTime(),
                       BookId = 3

                   });
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Roman"

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
                     GenreId = 1,
                     PageCount = 400,
                     PublisDate = new DateTime(2022, 07, 07)

                 },
                 new Book
                 {
                     
                     Title = "Deneme",
                     GenreId = 2,
                     PageCount = 250,
                     PublisDate = new DateTime(2012, 08, 23)

                 },
                 new Book
                 {
                     
                     Title = "Dune",
                     GenreId = 2,
                     PageCount = 489,
                     PublisDate = new DateTime(2002, 10, 01)

                 });
                
                context.SaveChanges();

            }
        }
    }
}
