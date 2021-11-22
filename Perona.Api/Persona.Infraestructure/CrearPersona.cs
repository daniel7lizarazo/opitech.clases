using Persona.Domain.DomainService;
using System.Collections.Generic;

namespace Persona.Infraestructure
{
    public class CrearPersona : ICrearPersona
    {
        private static IList<Domain.Persona>  PERSONAS = new List<Domain.Persona>();

        public CrearPersona()
        {

        }

        Domain.Persona ICrearPersona.CrearPersona(Domain.Persona persona)
        {
            PERSONAS.Add(persona);
            return persona;
        }
    }
}
