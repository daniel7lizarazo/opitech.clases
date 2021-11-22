using System;

namespace Persona.Domain
{
    public abstract class Entity<TEntity>
      where TEntity : IComparable, IComparable<TEntity>
    {
        public TEntity Id { get; set; }
    }
}
