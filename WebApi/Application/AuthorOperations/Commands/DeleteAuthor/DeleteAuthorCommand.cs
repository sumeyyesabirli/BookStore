using AutoMapper;
using System;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly DbContextBooksStore _dbcontext;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(DbContextBooksStore dbcontext)
        {
            _dbcontext = dbcontext;
            
        }

        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı ! ");

            _dbcontext.Authors.Remove(author);
            _dbcontext.SaveChanges();
        }    

    }
}
