using Hoga.Tech.DependecyInjection;
using Hoga.Tech.DependecyInjection.Interface;
using Moq;
using NUnit.Framework;
using Persona.Domain.Repositories;
using System.Threading.Tasks;

namespace UnitTest
{
    public class PersonCrudTest
    {
        private Persona.Domain.Persona persona;
        private IContainer container;

        [SetUp]
        public void Setup()
        {
            ContainerBuilder.StartIoC();
            ContainerBuilder.CleanCache();
            persona = new Persona.Domain.Persona
            {
                Edad = "20",
                IsValid = true,
                Nombre = "David",
                Id = "14134214"
            };
            var mockRepository = new Mock<IRepository<Persona.Domain.Persona, string>>();
            mockRepository.Setup(it => it.Insert(persona)).Returns(persona);
            mockRepository.Setup(it => it.Update(persona)).Returns(persona);
            mockRepository.Setup(it => it.InsertAsync(persona)).Returns(Task.FromResult(persona));
            container = ContainerBuilder.GetContainer();
            container.RegisterSingleton(mockRepository.Object);
        }

        [Test]
        public void CreatePersonTest()
        {
            var crudService = container.Resolve<Persona.Application.ApplicationService.ICrudService<Persona.Domain.Persona, string>>();
            var personaResult = crudService.Insert(persona);
            Assert.AreEqual(personaResult,persona);
        }



        [Test]
        public void UpdatePersonTest()
        {
            var crudService = container.Resolve<Persona.Application.ApplicationService.ICrudService<Persona.Domain.Persona, string>>();
            var personaResult = crudService.Update(persona);
            Assert.AreEqual(personaResult, persona);
        }


        [Test]
        public async Task CreatePersonAsyncTest()
        {
            var crudService = container.Resolve<Persona.Application.ApplicationService.ICrudService<Persona.Domain.Persona, string>>();
            var personaResult = await crudService.InsertAsync(persona);
            Assert.AreEqual(personaResult, persona);
        }
    }
}