using AutoMapper;
using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly DbContextBooksStore _dbcontext;

        public UpdateAuthorModel Model { get; set; }

        public int AuthorId { get; set; }

        public UpdateAuthorCommand(IMapper mapper, DbContextBooksStore dbcontext)
        {
           
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author == null)
                throw new InvalidOperationException("Yazar Bulunamadı ! ");

            author.BookId = Model.BookId != default ? Model.BookId : author.BookId;
            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.lastName = Model.lastName != default ? Model.lastName : author.lastName;

            _dbcontext.SaveChanges();

        }
    }
    public class UpdateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
    }
}
