using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }

        private readonly DbContextBooksStore _dbcontext;
        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(DbContextBooksStore dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _dbcontext.Authors.Include(x => x.Id);

            if (author is null)
                throw new InvalidOperationException("Yazar Bulunamadı !");

            AuthorDetailViewModel model = _mapper.Map<AuthorDetailViewModel>(author);
            return model;

        }

    }
    public class AuthorDetailViewModel
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

    }

}
