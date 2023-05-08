using System;
using DotNetBackendTemplate.Core.Entities;

namespace DotNetBackendTemplate.Entities.DTOs
{
    public class AccountForLoginDto : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

