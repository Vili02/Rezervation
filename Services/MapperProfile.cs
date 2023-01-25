﻿using AutoMapper;
using Rezervation.DTOs;
using Rezervation.Models;

namespace Rezervation.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterModel, User>();
            CreateMap<AuthenticateRequest, User>();

            CreateMap<OrganizerCrudDto, Organizer>();
            CreateMap<Organizer, OrganizerReturnDto>();
        }
    }
}