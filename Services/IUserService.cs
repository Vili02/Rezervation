using Rezervation.DTOs;
using Rezervation.Models;

namespace Rezervation.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<UserReturnDto> GetAll();

        UserReturnDto GetById(int id);

        UserReturnDto Create(RegisterModel model);

        UserReturnDto Update(int id, RegisterModel model);

        void Delete(int id);
    }
}
