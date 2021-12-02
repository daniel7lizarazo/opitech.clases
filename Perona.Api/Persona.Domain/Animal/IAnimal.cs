namespace Persona.Domain.Animal
{
    public interface IAnimal
    {
        public string Name { get; set; }

        void Comer();
    }
}
