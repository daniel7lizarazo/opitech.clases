namespace Persona.Application.Bridge
{
    public interface IConsignacion
    {
        bool Consigar(Consignar consignar);
    }

    public class Consignar
    {
        public TipoCuenta TipoCuenta { get; set; }

        public string NumeroCuetna { get; set; }

        public string TitularCuetna { get; set; }
    }
}
