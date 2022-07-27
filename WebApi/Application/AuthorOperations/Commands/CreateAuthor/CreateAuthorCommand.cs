using AutoMapper;
using System;
using System.Linq;
using WebApi.EfDbContext;

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
            var author = _dbcontext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author == null)
                throw new InvalidOperationException("Yazar Bulunamadı ! ");

            author.BookId = Model.BookId != default ? Model.BookId : author.BookId;
            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.lastName = Model.LastName != default ? Model.LastName : author.lastName;

            _dbcontext.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

}
