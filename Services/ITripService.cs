using Rezervation.DTOs;

namespace Rezervation.Services
{
    public interface ITripService
    {
        IEnumerable<TripReturnDto> GetAll();

        TripReturnDto GetById(int id);

        TripReturnDto Create(TripCrudDto dto);

        TripReturnDto Update(int id, TripCrudDto dto);

        void Delete(int id);
        int GetCount();
    }
}
