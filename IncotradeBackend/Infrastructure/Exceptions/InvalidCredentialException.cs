using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncotradeBackend.Infrastructure.Exceptions
{
    public class InvalidCredentialException : Exception
    {
        public string Error { get; }

        public InvalidCredentialException(string error) : base("Email hoặc mật khẩu không hợp lệ.")
        {
            Error = error;
        }
    }
}