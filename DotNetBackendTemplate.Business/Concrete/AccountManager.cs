using System;
using DotNetBackendTemplate.Business.Abstract;
using DotNetBackendTemplate.Core.Entities.Concrete;
using DotNetBackendTemplate.Core.Entities.DTOs;
using DotNetBackendTemplate.Core.Utilities.Results.Abstract;
using DotNetBackendTemplate.Core.Utilities.Results.Concrete;
using DotNetBackendTemplate.DataAccess.Abstract;

namespace DotNetBackendTemplate.Business.Concrete
{
    public class AccountManager : IAccountService
    {
        IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public IResult Add(Account account)
        {
            _accountDal.Add(account);
            return new SuccessResult();
        }

        public IResult Delete(Account account)
        {
            _accountDal.Delete(account);
            return new SuccessResult();
        }

        public IDataResult<List<Account>> GetAll()
        {
            return new SuccessDataResult<List<Account>>(_accountDal.GetAll());
        }

        public IDataResult<Account> GetByMail(string email)
        {
            return new SuccessDataResult<Account>(_accountDal.Get(a => a.Email == email));
        }

        public IDataResult<List<AccountOperationClaimDetailDto>> GetClaims(Account account)
        {
            return new SuccessDataResult<List<AccountOperationClaimDetailDto>>(_accountDal.GetClaims(account));
        }

        public IResult Update(Account account)
        {
            _accountDal.Update(account);
            return new SuccessResult();
        }
    }
}

