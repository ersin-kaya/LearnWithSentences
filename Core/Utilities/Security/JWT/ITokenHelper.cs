using System;
using Core.Entities.Concrete;
using Core.Entities.DTOs;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Account account, List<AccountOperationClaimDetailDto> operationClaims);
    }
}

