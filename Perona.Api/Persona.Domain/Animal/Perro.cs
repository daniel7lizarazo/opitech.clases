using Hoga.Tech.DependecyInjection.Attributes;

namespace Persona.Domain.Animal
{
    [DependName("Perro")]
    public class Perro : IAnimal
    {
        public string Name { get; set; }

        public string YoSoyPerro { get; set; }

        public void Comer()
        {
            throw new System.NotImplementedException();
        }
    }
}
