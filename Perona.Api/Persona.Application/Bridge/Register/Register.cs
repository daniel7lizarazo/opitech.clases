using Hoga.Tech.DependecyInjection;
using Hoga.Tech.DependecyInjection.Interface;
using System;
using System.Collections.Generic;

namespace Persona.Application.Bridge.Register
{
    public abstract class Register<TModel,TInterfaceBrige,TInterface> where TModel : class, new()
    {
        private List<Tuple<Func<TModel, bool>, Type>> Items = new List<Tuple<Func<TModel, bool>, Type>>();
        private IContainer _container;

        public Register()
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
            Type typeToResolve = null;
            foreach (var item in Items)
            {
                if (item.Item1(model))
                {
                    typeToResolve = item.Item2;
                    break;
                }
            }

            if(typeToResolve == null)
            {
                return default;
            }

            return (TInterface)_container.Resolve(typeToResolve);
        }
    }
}
