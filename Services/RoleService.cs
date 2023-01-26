using AutoMapper;
using Rezervation.Data;
using Rezervation.DTOs;
using Rezervation.Exceptions;
using Rezervation.Models;

namespace Rezervation.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public RoleService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public RoleReturnDto Create(RoleCrudDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            _context.Roles.Add(role);
            _context.SaveChanges();

            return _mapper.Map<RoleReturnDto>(role);
        }

        public void Delete(int id)
        {
            var role = _context.Roles.Find(id);
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        public IEnumerable<RoleReturnDto> GetAll()
        {
            return _context.Roles.Select(_mapper.Map<RoleReturnDto>).ToList();
        }

        public RoleReturnDto GetById(int id)
        {
            var role = _context.Roles.Find(id);
            return _mapper.Map<RoleReturnDto>(role);
        }

        public RoleReturnDto Update(int id, RoleCrudDto dto)
        {
            var role = _context.Roles.Find(id);

            _mapper.Map(dto, role);

            _context.Roles.Update(role);
            _context.SaveChanges();

            return _mapper.Map<RoleReturnDto>(role);
        }
    }
}
