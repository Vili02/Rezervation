using AutoMapper;
using Rezervation.Data;
using Rezervation.DTOs;
using Rezervation.Models;

namespace Rezervation.Services
{
    public class TripService : ITripService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly ITypeOfTransportService _typeOfTransportService;
        private readonly IUserService _userService;

        public TripService(ApiContext context, IMapper mapper, ITypeOfTransportService typeOfTransportService, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _typeOfTransportService = typeOfTransportService;
            _userService = userService;
        }

        public TripReturnDto Create(TripCrudDto dto)
        {
            var trip = _mapper.Map<Trip>(dto);

            trip.User = _userService.GetEntityById(dto.UserId);
            trip.TypeOfTransport = _typeOfTransportService.GetEntityById(dto.TypeOfTransportId);

            _context.Trips.Add(trip);
            _context.SaveChanges();

            return _mapper.Map<TripReturnDto>(trip);
        }

        public void Delete(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null)
            {
                return;
            }
            _context.Trips.Remove(trip);
            _context.SaveChanges();
        }

        public TripReturnDto Update(int id, TripCrudDto dto)
        {
            var trip = _context.Trips.Find(id);
            _mapper.Map(dto, trip);

            trip.User = _userService.GetEntityById(dto.UserId);
            trip.TypeOfTransport = _typeOfTransportService.GetEntityById(dto.TypeOfTransportId);

            _context.Trips.Update(trip);
            _context.SaveChanges();

            return _mapper.Map<TripReturnDto>(trip);
        }

        public IEnumerable<TripReturnDto> GetAll()
        {
            return _context.Trips.Select(_mapper.Map<TripReturnDto>).ToList();
        }

        public TripReturnDto GetById(int id)
        {
            return _mapper.Map<TripReturnDto>(_context.Trips.FirstOrDefault(x => x.Id == id));
        }
        public int GetCount()
        {
            return _context.Trips.Count();
        }
    }
}
    
