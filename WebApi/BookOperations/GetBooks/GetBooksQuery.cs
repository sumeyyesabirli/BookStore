using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetBooksQuery(DbContextBooksStore dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel>  Handle()
        {
            var booklist = _dbContext.Books.OrderBy(b => b.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(booklist);


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
