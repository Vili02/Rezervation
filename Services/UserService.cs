using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Rezervation.Models;
using Rezervation.DTOs;
using Rezervation.Data;
using AutoMapper;

namespace Rezervation.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration, ApiContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user.Id, token);
        }

        public UserReturnDto Create(RegisterModel model)
        {
            var user = _mapper.Map<User>(model);

            user.Role = _context.Roles.First(r => r.Name == "Admin");
            _context.Users.Add(user);
            _context.SaveChanges();

            return _mapper.Map<UserReturnDto>(user);
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserReturnDto> GetAll()
        {
            return _context.Users.Select(_mapper.Map<UserReturnDto>).ToList();
        }
        
        public UserReturnDto GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<UserReturnDto>(user);
        }

        public UserReturnDto Update(int id, RegisterModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            _mapper.Map(model, user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _context.Users.Update(user);
            _context.SaveChanges();

            return _mapper.Map<UserReturnDto>(user);
        }

        // helper methods

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 1 hour
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public int GetCount()
        {
            return _context.Users.Count();
        }

        public User GetEntityById(int id)
        {
            return _context.Users.First(u => u.Id == id);
        }
    }
}
