using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.EfDbContext;
using WebApi.Entities;

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
            var bookList = _dbContext.Books.Include(x => x.Genre). Where(x => x.IsPublished == true).Include(x => x.Author).OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);

            return vm;
        }

        public class BooksViewModel
        {
           
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublisDate { get; set; }
            
        }


    }
}
