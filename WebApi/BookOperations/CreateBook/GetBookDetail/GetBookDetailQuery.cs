using System;
using System.Linq;
using WebApi.Common;
using WebApi.EfDbContext;

namespace WebApi.BookOperations.CreateBook.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly DbContextBooksStore _dbContext;

        public int BookId { get; set; }
        public GetBookDetailQuery(DbContextBooksStore dbContext)
        {
            _dbContext = dbContext;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).FirstOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap Bulunumadı.");
             
            BookDetailViewModel  vm = new  BookDetailViewModel();
             vm.Title = book.Title;            
             vm.PageCount = book.PageCount;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            vm.PublisDate = book.PublisDate.Date.ToString("dd/MM/yyyy");
            return vm;
        }

    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublisDate { get; set; }
    }
}
