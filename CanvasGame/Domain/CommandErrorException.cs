using System;
using System.Runtime.Serialization;

namespace CanvasGame.Domain
{
    public class CommandErrorException : Exception
    {
        public CommandErrorException()
        {
        }

        public CommandErrorException(string message) : base(message)
        {
        }

        public CommandErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommandErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
