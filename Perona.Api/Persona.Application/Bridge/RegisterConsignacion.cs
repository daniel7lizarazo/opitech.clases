using Persona.Application.Bridge.ConcreteImpl;

namespace Persona.Application.Bridge
{
    public class RegisterConsignacion: Register.Register<Consignar,IConsignacion ,IDesembolsar>
    {
        public RegisterConsignacion() : base()
        {
            this.AddItem<DesembolsarCuentaAhorros>(it => { 
                return it.TipoCuenta == TipoCuenta.Ahorros; 
            }).AddItem<DesembolsarCuetnaCorriente>(it=> {
                return it.TipoCuenta == TipoCuenta.Corriente;
                });
        }
    }
}
