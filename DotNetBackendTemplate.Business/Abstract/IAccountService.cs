using System;
using DotNetBackendTemplate.Core.Entities.Concrete;
using DotNetBackendTemplate.Core.Entities.DTOs;
using DotNetBackendTemplate.Core.Utilities.Results.Abstract;

namespace DotNetBackendTemplate.Business.Abstract
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

