using System;
using System.Runtime.Serialization;

namespace Persona.Application.Exceptions
{
    [Serializable]
    public class RegisterNotFoundException: Exception
    {
        public RegisterNotFoundException(string message)
         : base(message)
        {
        }

        public RegisterNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected RegisterNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}