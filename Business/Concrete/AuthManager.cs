using System;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IAccountService _accountService;
        ITokenHelper _tokenHelper;

        public AuthManager(IAccountService accountService, ITokenHelper tokenHelper)
        {
            _accountService = accountService;
            _tokenHelper = tokenHelper;
        }

        public IResult AccountExists(string email)
        {
            if (_accountService.GetByMail(email).Data != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IDataResult<Account> Register(AccountForRegisterDto accountForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var account = new Account
            {
                Email = accountForRegisterDto.Email,
                FirstName = accountForRegisterDto.FirstName,
                LastName = accountForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PhoneNumber = accountForRegisterDto.PhoneNumber
            };
            _accountService.Add(account);

            return new SuccessDataResult<Account>(account);
        }

        public IDataResult<Account> Login(AccountForLoginDto accountForLoginDto)
        {
            var accountToCheck = _accountService.GetByMail(accountForLoginDto.Email).Data;
            if (accountToCheck == null)
            {
                return new ErrorDataResult<Account>();
            }

            if (!HashingHelper.VerifyPasswordHash(accountForLoginDto.Password, accountToCheck.PasswordHash, accountToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Account>();
            }

            return new SuccessDataResult<Account>(accountToCheck);
        }

        public IDataResult<AccessToken> CreateAccessToken(Account account)
        {
            var claims = _accountService.GetClaims(account).Data;
            var accessToken = _tokenHelper.CreateToken(account, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}

