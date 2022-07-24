using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly DbContextBooksStore _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(DbContextBooksStore dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle ()
        {

            var books = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);
            if (books is null)
                throw new InvalidOperationException("Silinecek Kitap Bulunamadı");

            _dbContext.Books.Remove(books);
            _dbContext.SaveChanges();
        }
    }

}
