using System;
using DotNetBackendTemplate.Core.DataAccess;
using DotNetBackendTemplate.Core.Entities.Concrete;
using DotNetBackendTemplate.Core.Entities.DTOs;

namespace DotNetBackendTemplate.DataAccess.Abstract
{
    public interface IAccountDal : IEntityRepository<Account>
    {
        List<AccountOperationClaimDetailDto> GetClaims(Account account);
    }
}

