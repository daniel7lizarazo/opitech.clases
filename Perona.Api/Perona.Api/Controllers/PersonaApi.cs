using Microsoft.AspNetCore.Mvc;
using Persona.Application.ApplicationService;

namespace Perona.Api.Controllers
{
    [ApiController]
    [Route("api/persona")]
    public class PersonaApi : ControllerBase
    {
        private readonly ICrearUserApplicationService crearUserApplicationService;
        public PersonaApi(ICrearUserApplicationService crearUserApplicationService)
        {
            this.crearUserApplicationService = crearUserApplicationService;
        }

        [HttpPost]
        public Persona.Domain.Persona CrearPersona(Persona.Domain.Persona perona)
        {
            return crearUserApplicationService.CrearPersona(perona);
        }
    }
}
