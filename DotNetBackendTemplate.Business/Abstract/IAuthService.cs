using System;
using DotNetBackendTemplate.Core.Entities.Concrete;
using DotNetBackendTemplate.Core.Utilities.Results.Abstract;
using DotNetBackendTemplate.Core.Utilities.Security.JWT;
using DotNetBackendTemplate.Entities.DTOs;

namespace DotNetBackendTemplate.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Account> Register(AccountForRegisterDto accountForRegisterDto, string password);
        IDataResult<Account> Login(AccountForLoginDto accountForLoginDto);
        IResult AccountExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Account account);
    }
}

