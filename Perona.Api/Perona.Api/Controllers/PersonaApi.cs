using Microsoft.AspNetCore.Mvc;
using Persona.Application.ApplicationService;

namespace Perona.Api.Controllers
{
    [ApiController]
    [Route("api/persona")]
    public class PersonaApi: BaseController<Persona.Domain.Persona, string>
    {
        public PersonaApi(ICrudService<Persona.Domain.Persona, string> crudService) : base(crudService)
        {
        }
    }
}
