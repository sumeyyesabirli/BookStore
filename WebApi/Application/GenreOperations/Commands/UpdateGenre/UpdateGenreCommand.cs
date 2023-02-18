using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }

        private readonly IBookStoreDbContext _dbContext;

        public UpdateGenreCommand(IBookStoreDbContext dbContext)
        {
            
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Güncellenecek Kitap Türü Bulunamadı");
            if (_dbContext.Genres.Any(x=>x.Name.ToLower()==Model.Name.ToLower() && x.Id!= GenreId))
                throw new InvalidOperationException("Aynı İsimli Kitap Türü Bulunuyor");

            genre.Name = String.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive=Model.IsActive;                 
            
            _dbContext.SaveChanges();

        }

        public class UpdateGenreModel
        {            
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
