using AutoMapper;
using System;
using System.Linq;
using WebApi.EfDbContext;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly DbContextBooksStore _dbcontext;
        private readonly IMapper _mapper;

        public int AuthorId { get; set; }
        public CreateAuthorModel Model { get; set; }

        public CreateAuthorCommand(DbContextBooksStore dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x => x.Name == Model.Name);

            if (author == null)
                throw new InvalidOperationException("Yazar Bulunamadı ! ");
            author = _mapper.Map<Author>(Model);

            _dbcontext.Authors.Add(author);
            _dbcontext.SaveChanges();

        }
    }
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }

}
