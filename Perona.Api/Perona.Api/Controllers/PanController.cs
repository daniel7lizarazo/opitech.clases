using Microsoft.AspNetCore.Mvc;
using Persona.Application.ApplicationService;
using Persona.Application.Dto;

namespace Perona.Api.Controllers
{
    [ApiController]
    [Route("api/pan")]
    public class PanController : BaseController<Persona.Domain.PanRoscon, string>
    {
        private readonly ICrearPan crearPan;

        public PanController(ICrudService<Persona.Domain.PanRoscon, string> crudService, ICrearPan crearPan) : base(crudService)
        {
            this.crearPan = crearPan;
        }
         
        [HttpPost]
        [Route("crearPan")]
        public CreatePanDto CrearPan(CreatePanDto createPanDto)
        {
            return this.crearPan.CrarPan(createPanDto);
        }
    }
}
