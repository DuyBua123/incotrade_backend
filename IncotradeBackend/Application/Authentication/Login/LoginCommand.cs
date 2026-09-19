using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncotradeBackend.Application.Authentication.Login
{
    public class LoginCommand
    {
        public string Email { get; init; } = string.Empty;

        public string Password { get; init; } = string.Empty;
    }
}