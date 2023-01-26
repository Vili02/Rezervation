using Rezervation.DTOs;
using Rezervation.Models;

namespace Rezervation.Services
{
    public interface IOrganizerService
    {

        IEnumerable<OrganizerReturnDto> GetAll();

        OrganizerReturnDto GetById(int id);

        OrganizerReturnDto Create(OrganizerCrudDto dto);

        OrganizerReturnDto Update(int id, OrganizerCrudDto dto);

        void Delete(int id);
        int GetCount();
    }
}
