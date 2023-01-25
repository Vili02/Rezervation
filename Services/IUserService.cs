using Rezervation.DTOs;
using Rezervation.Models;

namespace Rezervation.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<User> GetAll();
        
        User GetById(int id);

        void Create(User user);

        void Update(User user);

        void Delete(int id);
    }
}
