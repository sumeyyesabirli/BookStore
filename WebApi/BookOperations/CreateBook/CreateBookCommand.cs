using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get ; set; }

        private readonly DbContextBooksStore _dbContext;
        public CreateBookCommand(DbContextBooksStore dbContext)
        {
            _dbContext = dbContext;
        }
    
        public void Handle()
        {

            var book = _dbContext.Books.SingleOrDefault(b => b.Title == Model.Title);

            if (book is not null)
                throw new InvalidOperationException("Bu Kitap Ekli");
            book = new Book();
            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PageCount= Model.PageCount;
            book.PublisDate = Model.PublisDate;


            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
             
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublisDate { get; set; }
        }

    }
}
