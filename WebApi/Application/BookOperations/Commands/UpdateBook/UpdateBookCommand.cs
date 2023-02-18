using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;

        public int BookId { get; set; }

        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle ()
        {

            var books = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);

            if (books is null)
                throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı");

            books.GenreId = Model != default ? Model.GenreId : books.GenreId;
            // Soru işretinden öncesi if koşulu sonrası ifi için : sonrası da elsin için             
            books.Title = Model != default ? Model.Title : books.Title;
            _dbContext.SaveChanges();
           

        }

        public  class UpdateBookModel
        {
            public string Title { get; set; }
            public int  GenreId { get; set; }
           
        }
    }
}
