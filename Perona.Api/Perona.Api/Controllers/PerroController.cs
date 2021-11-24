using Microsoft.AspNetCore.Mvc;
using Persona.Application.ApplicationService;
using Persona.Domain;

namespace Perona.Api.Controllers
{
    [ApiController]
    [Route("api/perro")]
    public class PerroController: BaseController<Perro,int>
    {
        public PerroController(ICrudService<Perro, int> crudService) : base(crudService)
        {
        }
    }
}
