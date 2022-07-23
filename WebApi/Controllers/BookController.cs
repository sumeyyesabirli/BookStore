using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.CreateBook.GetBookDetail;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.EfDbContext;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DbContextBooksStore _context;
        private readonly IMapper _mapper;

        public BookController(DbContextBooksStore context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public  IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
           var result =  query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
                BookDetailViewModel result;           
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();           
            return Ok(result);
            
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel  newBooks)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);

            command.Model = newBooks;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            
         
            /// if (!result.IsValid)                
            ///     foreach (var item  in result.Errors)              
            ///         Console.WriteLine($"Özellik :{ item.PropertyName}: Hata mesajı {item.ErrorMessage}"); 
            /// else                
            ///     command.Handle();    
         
              return Ok();      

        }

        [HttpPut("{id}")]

        public IActionResult UpdateBooks (int id, [FromBody] UpdateBookModel updateBooks )
        {

            UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model= updateBooks;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();           
            return Ok();
           
            
        } 
        
        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id )
        {
            
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();           
            
                return Ok();
        }

    }

}
