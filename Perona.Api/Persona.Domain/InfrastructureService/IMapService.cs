namespace Persona.Domain.InfrastructureService
{
    public interface IMapService
    {
        public TTo Map<TFrom, TTo>(TFrom @object)
            where TTo: class, new()
            where TFrom: class;
    }
}
