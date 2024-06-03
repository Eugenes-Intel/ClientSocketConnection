﻿using System.Runtime.Serialization;

namespace QueClient.Exceptions
{
    public class ClientNotConnectedException : Exception
    {
        public ClientNotConnectedException()
        {
        }

        public ClientNotConnectedException(string? message) : base(message)
        {
        }

        public ClientNotConnectedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ClientNotConnectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
