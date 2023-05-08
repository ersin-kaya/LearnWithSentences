using System;
using DotNetBackendTemplate.Core.Entities.Concrete;
using DotNetBackendTemplate.Core.Entities.DTOs;

namespace DotNetBackendTemplate.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Account account, List<AccountOperationClaimDetailDto> operationClaims);
    }
}

