using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.EfDbContext;

namespace Tests.TestSetup
{
    public class CommonTestFixture
    {
        public DbContextBooksStore Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<DbContextBooksStore>()
            .UseInMemoryDatabase(databaseName: "DbContextBooksStore").Options;

            Context = new DbContextBooksStore(options);

            Context.Database.EnsureCreated();

            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(
                cfg => { cfg.AddProfile<MappingProfile>();}).CreateMapper();
        }
    }
}
