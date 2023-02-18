using AutoMapper;
using System;
using System.Linq;
using WebApi.EfDbContext;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {

        public CreateGrenreModel Model { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        

        public CreateGenreCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
         
        }
        public void Handle()
        {   
            var genre = _dbContext.Genres.SingleOrDefault(g => g.Name == Model.Name);

            if (genre is not null)
                throw new InvalidOperationException("Bu Kitap Türü Ekli");
            genre = new Genre();       
            genre.Name =Model.Name;
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
       
    }
    public class CreateGrenreModel
    {        
        public string Name { get; set; }
    }
}
