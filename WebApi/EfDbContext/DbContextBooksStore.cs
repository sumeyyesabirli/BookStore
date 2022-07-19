using Microsoft.EntityFrameworkCore;

namespace WebApi.EfDbContext
{
    public class DbContextBooksStore : DbContext
    {
        public DbContextBooksStore(DbContextOptions<DbContextBooksStore>options): base(options)
        { }

        public DbSet<Book> Books { get; set; }

    }
}
