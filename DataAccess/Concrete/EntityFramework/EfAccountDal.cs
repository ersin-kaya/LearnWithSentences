using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAccountDal : EfEntityRepositoryBase<Account, BaseDbContext>, IAccountDal
    {
        public List<AccountOperationClaimDetailDto> GetClaims(Account account)
        {
            using (var context = new BaseDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join accountOperationClaim in context.AccountOperationClaims
                             on operationClaim.Id equals accountOperationClaim.OperationClaimId
                             where accountOperationClaim.AccountId == account.Id
                             select new AccountOperationClaimDetailDto { OperationClaimId = operationClaim.Id, OperationClaimName = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}

