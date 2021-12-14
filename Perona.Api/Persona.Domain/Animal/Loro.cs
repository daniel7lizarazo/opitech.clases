using Hoga.Tech.DependecyInjection.Attributes;

namespace Persona.Domain.Animal
{
    [DependName("Loro")]
    public class Loro : IAnimal
    {
        public string? YoSoyLoro { get; set; }
        public string? Name { get; set; }

        public void Comer()
        {
            throw new System.NotImplementedException();
        }
    }
}
