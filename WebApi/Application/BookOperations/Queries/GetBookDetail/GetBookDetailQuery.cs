using AutoMapper;
using System;
using System.Linq;
using WebApi.Common;
using WebApi.EfDbContext;

namespace WebApi.BookOperations.CreateBook.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly DbContextBooksStore _dbContext;
        private readonly IMapper _mapper;

        public int BookId { get; set; }
        public GetBookDetailQuery(DbContextBooksStore dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).FirstOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap Bulunumadı.");

             
            BookDetailViewModel  vm =  _mapper.Map<BookDetailViewModel>(book);
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
