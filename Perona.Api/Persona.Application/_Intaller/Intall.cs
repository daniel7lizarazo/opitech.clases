using Hoga.Tech.DependecyInjection.Enum;
using Hoga.Tech.DependecyInjection.Interface;
using Persona.Application.ApplicationService;
using Persona.Application.ApplicationService.Impl;
using Persona.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Persona.Application._Intaller
{
    public class Intall : IModuleIoC
    {

        private List<Type> registers = new List<Type>();

        public IContainer Container { get; set; }

        public void IoCStartUpCompleted()
        {
            registers.ForEach(it => {
                var paramtersInfo = it.GetConstructors().FirstOrDefault(it => it.IsPublic).GetParameters();
                var parameters = new List<object>();
                paramtersInfo?.ToList().ForEach(paramter => parameters.Add(Container.Resolve(paramter.ParameterType)));
                var obj = parameters.Any() ? Activator.CreateInstance(it, parameters): Activator.CreateInstance(it);
                Container.RegisterSingleton(obj.GetType(),obj);
            });
        }

        public void Register()
        {
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
                Container.RegisterTransient(typeof(ICrudService<,>).MakeGenericType(it, typeBaseId), typeof(CrudService<,>).MakeGenericType(it, typeBaseId));
            });


            registers = Container.GetAllTypesClass().Where(it => it.IsClass && it.IsPublic && !it.IsAbstract && it.GetConstructors().Any(itC => itC.IsPublic) &&
            it.BaseType.IsGenericType && it.BaseType.GetGenericTypeDefinition() == typeof(Bridge.Register.Register<,,>)).ToList();

            registers.ForEach(it =>
            {
                var bridge = it.BaseType.GetGenericArguments()[1];
                Container.RegisterFirtsImplementation(bridge);       
            });
        }
    }
}
