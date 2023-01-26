using AutoMapper;
using Rezervation.Data;
using Rezervation.DTOs;
using Rezervation.Models;

namespace Rezervation.Services
{
    public class TypeOfTransportService : ITypeOfTransportService
    {
        
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public TypeOfTransportService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TypeOfTransportReturnDto Create(TypeOfTransportCrudDto dto)
        {
            var typeoftransport = _mapper.Map<TypeOfTransport>(dto);
            _context.TypeOfTransports.Add(typeoftransport);
            _context.SaveChanges();

            return _mapper.Map<TypeOfTransportReturnDto>(typeoftransport);
        }

        public void Delete(int id)
        {
            var typeoftransport = _context.TypeOfTransports.Find(id);
            if (typeoftransport == null)
            {
                return;
            }
            _context.TypeOfTransports.Remove(typeoftransport);
            _context.SaveChanges();
        }

        public TypeOfTransportReturnDto Update(int id, TypeOfTransportCrudDto dto)
        {
            var typeoftransport = _context.Organizers.Find(id);
            _mapper.Map(dto, typeoftransport);
            _context.Organizers.Update(typeoftransport);
            _context.SaveChanges();

            return _mapper.Map<TypeOfTransportReturnDto>(typeoftransport);
        }

        public IEnumerable<TypeOfTransportReturnDto> GetAll()
        {
            return _context.TypeOfTransports.Select(_mapper.Map<TypeOfTransportReturnDto>).ToList();
        }

        public TypeOfTransportReturnDto GetById(int id)
        {
            return _mapper.Map<TypeOfTransportReturnDto>(_context.TypeOfTransports.FirstOrDefault(x => x.Id == id));
        }
    }
}
