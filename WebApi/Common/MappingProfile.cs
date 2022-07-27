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
            //CreateBookModel objesi Book modele maplenebilir demek 
            CreateMap<CreateBookModel, Book>();
            //vm.Genre = ((GenreEnum)book.GenreId).ToString();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            //BooksViewModel içerisindeki Genre src üzerindei yani book içindeki GenreId yi GenreEnum dan cast ederecek GenreId string olarak bana döndür
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src  => src.Genre.Name));
            CreateMap<Genre,GenreWiewModel>();
            CreateMap<Genre, GenreWiewModel>();
            CreateMap<Genre, GenreDetailWiewModel>();
            CreateMap<Author, AuthorviewModel>().ForMember(dest => dest.Book , opt => opt.MapFrom(src => src.Book.Title));
            CreateMap<Author, AuthorDetailViewModel>().ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<UpdateBookModel, Book>();



        }
    }
}
