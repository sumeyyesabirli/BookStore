using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.EfDbContext;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthor
{
    public class GetAuthorQuery
    {
        private readonly DbContextBooksStore _dbcontext;
        private readonly IMapper _mapper;

        public GetAuthorQuery(DbContextBooksStore dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }


        public List<AuthorviewModel> Handle()
        {
           
         // var authors = _dbcontext.Authors.Include(x => x.Book).OrderBy(x => x.Id).ToList();
         // List<AuthorviewModel> values = _mapper.Map<List<AuthorviewModel>>(authors);
         // return values;


            var authorList = _dbcontext.Authors.OrderBy(x => x.Id).ToList<Author>();
            List<AuthorviewModel> vm = _mapper.Map<List<AuthorviewModel>>(authorList);

            return vm;
        }
        public class AuthorviewModel
        {
         
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime BirthDay { get; set; }
        }


    }   
}
