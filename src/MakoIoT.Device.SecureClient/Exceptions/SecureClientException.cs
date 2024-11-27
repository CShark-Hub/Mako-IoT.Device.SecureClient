
using System;

namespace MakoIoT.Device.SecureClient.Exceptions
{
    public class SecureClientException : Exception
    {
        public SecureClientException(string message) : base(message)
        {
        }

        public SecureClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
