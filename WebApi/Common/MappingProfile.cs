using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations.CreateBook.GetBookDetail;
using WebApi.Entities;
using static WebApi.Application.AuthorOperations.Queries.GetAuthor.GetAuthorQuery;
using static WebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBooks.GetBooksQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //Book Maps
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().
                ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).
                ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name)).
                ForMember(dest => dest.PublisDate, opt => opt.MapFrom(src => src.PublisDate.ToShortDateString()));

            CreateMap<Book, BooksViewModel>().
                ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).
                ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name)).
                ForMember(dest => dest.PublisDate, opt => opt.MapFrom(src => src.PublisDate.ToShortDateString()));

            // Genre Maps
            CreateMap<Genre, GenreWiewModel>();
            CreateMap<Genre, GenreDetailWiewModel>();

            // Author Maps
            CreateMap<Author, AuthorviewModel>();

            CreateMap<Author, AuthorDetailViewModel>().ForMember(d => d.Birthday, opt => opt.MapFrom(src => src.Birthday.ToShortDateString()));

            CreateMap<CreateAuthorModel, Author>().ForMember(d => d.Birthday, opt => opt.MapFrom(src => src.BirthDay.ToShortDateString()));



        }
    }
}
