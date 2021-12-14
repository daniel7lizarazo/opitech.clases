using Hoga.Tech.DependecyInjection;
using Hoga.Tech.DependecyInjection.Interface;
using Moq;
using NUnit.Framework;
using Persona.Application.Bridge;
using Persona.Application.Exceptions;

namespace UnitTest
{
    public class BridgeTest
    {
        private IContainer container;

        [SetUp]
        public void Setup()
        {
            ContainerBuilder.StartIoC();
            ContainerBuilder.CleanCache();
            container = ContainerBuilder.GetContainer();
        }


        [Test]
        public void NotFoundAcountTypeTest()
        {          
            Assert.Throws<RegisterNotFoundException>(()=> {
                var crudService = container.Resolve<IConsignacion>();
                crudService.Consigar(new Consignar
                {
                    TipoCuenta = TipoCuenta.Credito,
                    NumeroCuetna = "124143",
                    TitularCuetna = "3242134124"
                });
            });
        }


        [Test]
        public void ConsignarAhorroTest()
        {
            var crudService = container.Resolve<IConsignacion>();
            var consignacion = crudService.Consigar(new Consignar
            {
                TipoCuenta = TipoCuenta.Ahorros,
                NumeroCuetna = "124143",
                TitularCuetna = "3242134124"
            });

            Assert.IsTrue(consignacion);
        }


        [Test]
        public void ConsignarCorrienteTest()
        {
            var crudService = container.Resolve<IConsignacion>();
            var consignacion = crudService.Consigar(new Consignar
            {
                TipoCuenta = TipoCuenta.Corriente,
                NumeroCuetna = "124143",
                TitularCuetna = "3242134124"
            });

            Assert.IsTrue(consignacion);
        }
    }
}
