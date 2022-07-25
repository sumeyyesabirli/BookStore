using AutoMapper;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations.CreateBook.GetBookDetail;
using WebApi.Entities;
using static WebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBooks.GetBooksQuery;

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


        }
    }
}
