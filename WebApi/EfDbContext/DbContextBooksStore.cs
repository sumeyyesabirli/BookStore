using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.EfDbContext
{
    public class DbContextBooksStore : DbContext
    {
        public DbContextBooksStore(DbContextOptions<DbContextBooksStore>options): base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
