using AutoMapper;
using Persona.Application.Dto;
using Persona.Domain;

namespace Persona.Infraestructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PanRoscon, CreatePanDto>();
        }
    }
}