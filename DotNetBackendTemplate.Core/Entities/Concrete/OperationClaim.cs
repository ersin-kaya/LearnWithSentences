using System;
namespace DotNetBackendTemplate.Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
    }
}

