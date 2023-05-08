using System;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Account> Register(AccountForRegisterDto accountForRegisterDto, string password);
        IDataResult<Account> Login(AccountForLoginDto accountForLoginDto);
        IResult AccountExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Account account);
    }
}

