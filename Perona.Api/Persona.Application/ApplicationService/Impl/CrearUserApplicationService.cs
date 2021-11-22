using Persona.Domain.DomainService;

namespace Persona.Application.ApplicationService.Impl
{
    public class CrearUserApplicationService : ICrearUserApplicationService
    {

        private readonly ICrearPersona crearPersona;

        public CrearUserApplicationService(ICrearPersona crearPersona)
        {
            this.crearPersona = crearPersona;
        }

        public Domain.Persona CrearPersona(Domain.Persona persona)
        {
            return crearPersona.CrearPersona(persona);
        }
    }
}
