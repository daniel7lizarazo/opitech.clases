using AutoMapper;
using Persona.Domain.InfrastructureService;

namespace Persona.Infraestructure
{
    public class MapService : IMapService
    {
        private readonly IMapper mapper;
        public MapService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TTo Map<TFrom, TTo>(TFrom @object)
            where TFrom : class
            where TTo : class, new()
        {
            return mapper.Map<TFrom, TTo>(@object);
        }
    }
}
