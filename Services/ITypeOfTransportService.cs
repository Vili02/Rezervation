using Rezervation.DTOs;

namespace Rezervation.Services
{
    public interface ITypeOfTransportService
    {
        IEnumerable<TypeOfTransportReturnDto> GetAll();

        TypeOfTransportReturnDto GetById(int id);

        TypeOfTransportReturnDto Create(TypeOfTransportCrudDto dto);

        TypeOfTransportReturnDto Update(int id, TypeOfTransportCrudDto dto);

        void Delete(int id);
    }
}
