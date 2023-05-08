using System;
using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IAccountDal : IEntityRepository<Account>
    {
        List<AccountOperationClaimDetailDto> GetClaims(Account account);
    }
}

