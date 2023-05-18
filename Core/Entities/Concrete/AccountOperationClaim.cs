using System;
namespace Core.Entities.Concrete
{
    public class AccountOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int OperationClaimId { get; set; }
    }
}

