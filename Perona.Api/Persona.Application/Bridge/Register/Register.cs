using Hoga.Tech.DependecyInjection;
using Hoga.Tech.DependecyInjection.Interface;
using Persona.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persona.Application.Bridge.Register
{
    public abstract class Register<TModel,TInterfaceBrige,TInterface> where TModel : class, new()
    {
        private readonly List<Tuple<Func<TModel, bool>, Type>> Items = new List<Tuple<Func<TModel, bool>, Type>>();
        private readonly IContainer _container;

        protected Register()
        {
            _container = ContainerBuilder.GetContainer();
        }

        public Register<TModel, TInterfaceBrige, TInterface> AddItem<TImp>(Func<TModel, bool> func) where TImp: TInterface
        {
            _container.RegisterTransient(typeof(TImp), typeof(TImp));
            Items.Add(new Tuple<Func<TModel, bool>, Type>(func,typeof(TImp)));
            return this;
        }

        public TInterface ResolveInstance(TModel model)
        {
            Type typeToResolve = Items.FirstOrDefault(it => it.Item1(model)).Item2; 

            if(typeToResolve == null)
            {
                throw new RegisterNotFoundException("Not register type");
            }

            return (TInterface)_container.Resolve(typeToResolve);
        }
    }
}
