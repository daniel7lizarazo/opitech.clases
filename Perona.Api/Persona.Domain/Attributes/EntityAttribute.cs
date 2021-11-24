using System;

namespace Persona.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityAttribute : Attribute
    {
        public string CollectionName { get; private set; }

        public EntityAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
