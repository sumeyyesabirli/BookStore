using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.EfDbContext;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly DbContextBooksStore _dbContext;
        public GetBooksQuery(DbContextBooksStore dbContext)
        {
            _dbContext = dbContext;
        }
        public List<BooksViewModel>  Handle()
        {
            var booklist = _dbContext.Books.OrderBy(b => b.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in booklist)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublisDate = book.PublisDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount,

                });
            }

            return vm;
        }

        public class BooksViewModel
        {
           
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublisDate { get; set; }
            
        }


    }
}
