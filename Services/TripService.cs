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

        public TripService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TripReturnDto Create(TripCrudDto dto)
        {
            var trip = _mapper.Map<Trip>(dto);
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
    }
}
    
