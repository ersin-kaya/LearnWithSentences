using System;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IAccountService
    {
        IResult Add(Account account);
        IResult Update(Account account);
        IResult Delete(Account account);
        IDataResult<List<Account>> GetAll();
        IDataResult<Account> GetByMail(string email);
        IDataResult<List<AccountOperationClaimDetailDto>> GetClaims(Account account);
    }
}

