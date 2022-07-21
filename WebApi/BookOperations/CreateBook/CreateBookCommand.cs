﻿using AutoMapper;
using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get ; set; }

        private readonly DbContextBooksStore _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(DbContextBooksStore dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {

            var book = _dbContext.Books.SingleOrDefault(b => b.Title == Model.Title);

            if (book is not null)
                throw new InvalidOperationException("Bu Kitap Ekli");
            book = _mapper.Map<Book>(Model);


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
