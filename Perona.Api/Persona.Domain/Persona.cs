using System;

namespace Persona.Domain
{
    public class Persona : Entity<string>
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }

        public bool IsValid { set; get; }
    }
}
