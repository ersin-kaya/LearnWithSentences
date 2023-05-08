using System;
using DotNetBackendTemplate.Core.Entities;

namespace DotNetBackendTemplate.Entities.DTOs
{
    public class AccountForRegisterDto : IDTO
    {
        public int AccountTypeId { get; set; }
        public int AccountStatusId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}

