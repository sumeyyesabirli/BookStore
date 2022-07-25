using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly DbContextBooksStore _dbcontext;

        public int GenreId { get; set; } 

        public DeleteGenreCommand(DbContextBooksStore dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var genre = _dbcontext.Genres.SingleOrDefault(g => g.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Silinecek Kitap Türü Bulunamadı");

            _dbcontext.Genres.Remove(genre);
            _dbcontext.SaveChanges();

        }
    }
}
