using System;
using WebApi.EfDbContext;

namespace WebApi.Application.UserOperations.Commands.DeleteUser
{
    public class DeleteUserCommand
    {
        private readonly IBookStoreDbContext _context;
        public int UserID;

        public DeleteUserCommand(IBookStoreDbContext context)
        {

            _context = context;
        }

        public void Handle()
        {
            var user = _context.Users.Find(UserID);


            if (user == null)
                throw new InvalidOperationException("User ");

            _context.Users.Remove(user);
            _context.SaveChanges();

        }
    }
}
