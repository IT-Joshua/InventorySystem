using System;

namespace Frontend.Authentication;

 public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
            : base("User is not authorized to access this resource.")
        {
        }

        public UnauthorizedException(string message)
            : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }