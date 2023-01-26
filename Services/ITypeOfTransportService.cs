using Rezervation.DTOs;
using Rezervation.Models;

namespace Rezervation.Services
{
    public interface ITypeOfTransportService
    {
        IEnumerable<TypeOfTransportReturnDto> GetAll();

        TypeOfTransportReturnDto GetById(int id);

        TypeOfTransportReturnDto Create(TypeOfTransportCrudDto dto);

        TypeOfTransportReturnDto Update(int id, TypeOfTransportCrudDto dto);

        void Delete(int id);
        int GetCount();
        TypeOfTransport GetEntityById(int id);
    }
}
