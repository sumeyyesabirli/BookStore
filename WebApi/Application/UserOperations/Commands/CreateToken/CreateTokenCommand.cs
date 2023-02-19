using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using WebApi.EfDbContext;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        private readonly IConfiguration _configuration;
        public CreateTokenModel Model;

        public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }


        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user != null)
            {

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Experation.AddMinutes(5);

                _context.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı adı veya Şifre Hatalı !");
            }

        }

    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
