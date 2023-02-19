using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.EfDbContext;

namespace WebApi.Application.UserOperations.Queries.GetUser
{
    public class GetUsersQuery
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public GetUsersQuery Model;

        public GetUsersQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<GetUsersModel> Handle()
        {
            var userList = _context.Users.Where(x => x.IsActive == true).ToList();


            List<GetUsersModel> model = _mapper.Map<List<GetUsersModel>>(userList);
            return model;
        }
    }

    public class GetUsersModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}

