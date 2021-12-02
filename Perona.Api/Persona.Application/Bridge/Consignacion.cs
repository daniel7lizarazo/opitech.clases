namespace Persona.Application.Bridge
{
    public class Consignacion : IConsignacion
    {
        private readonly RegisterConsignacion registerConsignacion;
        public Consignacion(RegisterConsignacion registerConsignacion)
        {
            this.registerConsignacion = registerConsignacion;
        }

        public bool Consigar(Consignar consignar)
        {
            return registerConsignacion.ResolveInstance(consignar).Desembolsar(consignar.NumeroCuetna, consignar.TitularCuetna);
        }
    }
}
