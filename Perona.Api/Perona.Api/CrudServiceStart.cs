using Microsoft.Extensions.DependencyInjection;
using Persona.Application.ApplicationService;
using Persona.Application.ApplicationService.Impl;
using Persona.Domain;
using Persona.Domain.Attributes;
using Persona.Domain.Repositories;
using Persona.Infraestructure;
using System;
using System.Linq;
using System.Reflection;

namespace Perona.Api
{
    public static class CrudServiceStart
    {


        public static void StartEntities(this IServiceCollection services, Assembly assembly)
        {
            var entities = assembly.GetTypes().Where(it => it.IsClass && !it.IsAbstract && it.GetCustomAttribute<EntityAttribute>() != null);

            if(entities.Any() && entities.GroupBy(it=> it.GetCustomAttribute<EntityAttribute>().CollectionName).Any(it=> it.Count() > 1)){
                throw new Exception("Duplicate entities from name");
            }


            var mongoHost = Environment.GetEnvironmentVariable("MogonHost");
            var mongoDb = Environment.GetEnvironmentVariable("Database");
            entities.ToList().ForEach(it =>
            {
                var typeBaseId = it.GetProperty("Id").PropertyType;
                services.AddScoped(typeof(IRepository<,>).MakeGenericType(it, typeBaseId), serviceProviders =>
                {
                    var typeInstance = typeof(MongoRepository<,>).MakeGenericType(it, typeBaseId);
                    return Activator.CreateInstance(typeInstance, mongoHost, mongoDb);
                });
                services.AddTransient(typeof(ICrudService<,>).MakeGenericType(it, typeBaseId),
                     serviceProviders =>
                     {
                         var typeInstance = typeof(IRepository<,>).MakeGenericType(it, typeBaseId);
                         var instanceResolve = serviceProviders.GetService(typeInstance);
                         return Activator.CreateInstance(typeof(CrudService<,>).MakeGenericType(it, typeBaseId), instanceResolve);
                     });
            });
        }
    }
}
