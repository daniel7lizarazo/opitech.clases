using Microsoft.Extensions.DependencyInjection;
using Persona.Application.ApplicationService;
using Persona.Application.ApplicationService.Impl;
using Persona.Domain;
using Persona.Domain.Repositories;
using Persona.Infraestructure;
using System;

namespace Perona.Api
{
    public static class ServiceExtensions
    {
        public static void AddEntity<TEntity, TId>(this IServiceCollection services)
            where TEntity : Entity<TId>, new()
            where TId : IComparable, IComparable<TId>
        {
            var mongoHost = Environment.GetEnvironmentVariable("MogonHost");
            var mongoDb = Environment.GetEnvironmentVariable("Database");
            services.AddScoped <IRepository<TEntity, TId>> (it => new MongoRepository<TEntity, TId>(mongoHost, mongoDb));
            services.AddTransient<ICrudService<TEntity, TId>, CrudService<TEntity, TId>>();
        }

    }
}
