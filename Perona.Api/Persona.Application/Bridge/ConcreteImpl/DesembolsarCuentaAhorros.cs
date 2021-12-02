using System;

namespace Persona.Application.Bridge.ConcreteImpl
{
    public class DesembolsarCuentaAhorros : IDesembolsar
    {
        public bool Desembolsar(string numeroCuetna, string titular)
        {
            return true;
        }
    }
}
