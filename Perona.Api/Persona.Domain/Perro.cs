using Persona.Domain.Attributes;

namespace Persona.Domain
{
    [Entity("PerrosMasGrandes")]
    public class Perro: Entity<int>
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }

        public bool IsValid { set; get; }
    }
}
