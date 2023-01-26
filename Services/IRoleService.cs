using Rezervation.DTOs;

namespace Rezervation.Services
{
    public interface IRoleService
    {
        RoleReturnDto Create(RoleCrudDto dto);

        RoleReturnDto Update(int id, RoleCrudDto dto);

        RoleReturnDto GetById(int id);

        IEnumerable<RoleReturnDto> GetAll();

        void Delete(int id);
        int GetCount();
    }
}
