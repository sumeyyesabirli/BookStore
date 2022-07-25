using AutoMapper;
using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenrId { get; set; }

        public readonly DbContextBooksStore _dbcontext;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(DbContextBooksStore dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public GenreDetailWiewModel Handle()
        {
            var genre = _dbcontext.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenrId);
            
            if (genre is null)
                throw new InvalidOperationException("Kitap Türü Bulunumadı."); 

            return _mapper.Map<GenreDetailWiewModel>(genre);
        }

    }

    public class GenreDetailWiewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}
