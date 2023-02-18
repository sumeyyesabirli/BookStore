using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly IBookStoreDbContext _dbcontext;
        public readonly IMapper _mapper;
        public GetGenresQuery(IBookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<GenreWiewModel> Handle()
        {
            var genres = _dbcontext.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenreWiewModel> returnobj = _mapper.Map<List<GenreWiewModel>>(genres);
            return returnobj;
        }
    }

    public class GenreWiewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}
