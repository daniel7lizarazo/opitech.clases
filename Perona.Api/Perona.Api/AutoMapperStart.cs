using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Persona.Infraestructure;

namespace Perona.Api
{
    public static class AutoMapperStart
    {
        public static void StartAutomapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }  
    }
}
