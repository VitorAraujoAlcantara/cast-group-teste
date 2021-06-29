using System;
using System.Runtime.Serialization;

namespace castgroup.services.Exceptions
{
    [Serializable]
    public class CursoExistentePeriodoException : CustomException
    {
        public CursoExistentePeriodoException(string message) : base(message)
        {
        }

        public CursoExistentePeriodoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CursoExistentePeriodoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
