using AutoMapper;
using Rezervation.Data;
using Rezervation.DTOs;
using Rezervation.Models;

namespace Rezervation.Services
{
    public class OrganizerService : IOrganizerService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public OrganizerService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrganizerReturnDto Create(OrganizerCrudDto dto)
        {
            Organizer organizer = _mapper.Map<Organizer>(dto);
            _context.Organizers.Add(organizer);
            _context.SaveChanges();

            return _mapper.Map<OrganizerReturnDto>(organizer);
        }

        public void Delete(int id)
        {
            var organizer = _context.Organizers.Find(id);
            _context.Organizers.Remove(organizer);
            _context.SaveChanges();
        }

        public OrganizerReturnDto Update(int id, OrganizerCrudDto dto)
        {
            Organizer organizer = _context.Organizers.Find(id);
            _mapper.Map(dto, organizer);
            _context.Organizers.Update(organizer);
            _context.SaveChanges();

            return _mapper.Map<OrganizerReturnDto>(organizer);
        }

        public IEnumerable<OrganizerReturnDto> GetAll()
        {
            return _context.Organizers.Select(_mapper.Map<OrganizerReturnDto>).ToList();
        }

        public OrganizerReturnDto GetById(int id)
        {
            return _mapper.Map<OrganizerReturnDto>(_context.Organizers.FirstOrDefault(x => x.Id == id));
        }
    }
}
