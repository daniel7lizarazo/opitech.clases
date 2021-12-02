using Hoga.Tech.DependecyInjection.Interface;
using Microsoft.AspNetCore.Mvc;
using Persona.Application.Bridge;
using Persona.Domain.Animal;

namespace Perona.Api.Controllers
{
    [ApiController]
    [Route("api/animal")]
    public class AnimalInstnace: ControllerBase
    {
        private readonly IContainer container;
        private readonly IConsignacion consignacion;

        public AnimalInstnace(IContainer container, IConsignacion consignacion)
        {
            this.container = container;
            this.consignacion = consignacion;   
        }

        [Route("{name}")]
        [HttpGet]
        public  IAnimal GetAnimal(string name)
        {
            return container.Resolve<IAnimal>(name);
        }

        [HttpPost]
        public bool GetAnimal(Consignar consignar)
        {
            return consignacion.Consigar(consignar);
        }
    }
}
