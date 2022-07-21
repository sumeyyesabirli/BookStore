using AutoMapper;
using WebApi.BookOperations.CreateBook.GetBookDetail;
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
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            //BooksViewModel içerisindeki Genre src üzerindei yani book içindeki GenreId yi GenreEnum dan cast ederecek GenreId string olarak bana döndür
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
