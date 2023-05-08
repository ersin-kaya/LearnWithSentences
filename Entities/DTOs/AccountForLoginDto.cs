using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class AccountForLoginDto : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

