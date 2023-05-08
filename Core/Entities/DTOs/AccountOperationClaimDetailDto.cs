using System;
namespace Core.Entities.DTOs
{
    public class AccountOperationClaimDetailDto : IDTO
    {
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
    }
}

