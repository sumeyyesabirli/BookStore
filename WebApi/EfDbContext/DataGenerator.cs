using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
