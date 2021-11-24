﻿using Persona.Domain.Attributes;

namespace Persona.Domain
{
    [Entity("PersonasNuevas")]
    public class Persona : Entity<string>
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }

        public bool IsValid { set; get; }
    }
}
