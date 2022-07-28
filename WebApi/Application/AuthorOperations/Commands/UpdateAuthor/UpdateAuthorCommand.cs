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

        public UpdateAuthorCommand( DbContextBooksStore dbcontext)
        {
           
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Yazar Bulunamadı ! ");

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Birthday = Model.Birthday != default ? Model.Birthday : author.Birthday;

            _dbcontext.SaveChanges();

        }
    }
    public class UpdateAuthorModel
    {
        
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
