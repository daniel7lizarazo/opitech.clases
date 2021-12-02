using AutoMapper;
using Hoga.Tech.DependecyInjection.Enum;
using Hoga.Tech.DependecyInjection.Interface;
using Persona.Domain.Animal;
using Persona.Domain.Attributes;
using Persona.Domain.Repositories;
using System;
using System.Linq;
using System.Reflection;

namespace Persona.Infraestructure._Intaller
{
    public class Intall : IModuleIoC
    {
        public IContainer Container { get; set; }

        public void IoCStartUpCompleted()
        {
          
        }

        public void Register()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            Container.RegisterSingleton(mapper);


            var animales = Container.GetAllTypesClass().Where(it => it.IsClass && !it.IsAbstract && typeof(IAnimal).IsAssignableFrom(it));

            animales.ToList().ForEach(animal => {
                Container.RegisterTransient(typeof(IAnimal), animal);
            });
                    
            var entities = Container.GetAllTypesClass().Where(it => it.IsClass && !it.IsAbstract && it.GetCustomAttribute<EntityAttribute>() != null);

            if (entities.Any() && entities.GroupBy(it => it.GetCustomAttribute<EntityAttribute>().CollectionName).Any(it => it.Count() > 1))
            {
                throw new Exception("Duplicate entities from name");
            }

            var mongoHost = Environment.GetEnvironmentVariable("MogonHost");
            var mongoDb = Environment.GetEnvironmentVariable("Database");
            entities.ToList().ForEach(it =>
            {
                var typeBaseId = it.GetProperty("Id").PropertyType;
                var typeInstance = typeof(MongoRepository<,>).MakeGenericType(it, typeBaseId);
                var  instance =  Activator.CreateInstance(typeInstance, mongoHost, mongoDb);
                Container.RegisterSingleton(typeof(IRepository<,>).MakeGenericType(it, typeBaseId), instance);
            });
        }
    }
}
