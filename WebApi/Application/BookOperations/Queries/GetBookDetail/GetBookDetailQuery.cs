using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi.Common;
using WebApi.EfDbContext;

namespace WebApi.BookOperations.CreateBook.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int BookId { get; set; }
        public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Author).Include(x => x.Genre).Where(book => book.Id == BookId).FirstOrDefault();
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
        public string Author { get; set; }
        public int PageCount { get; set; }
        public string PublisDate { get; set; }
    }
}
