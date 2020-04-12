using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
    [Serializable]
    public class AuthException : Exception
    {
        public AuthException() { }
        public AuthException(string message) : base(message) { }
        public AuthException(string message, Exception inner) : base(message, inner) { }
        protected AuthException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
