using System;
using DotNetBackendTemplate.Core.Entities.Concrete;
using DotNetBackendTemplate.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DotNetBackendTemplate.DataAccess.Concrete.EntityFramework
{
	public class BaseDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1234;Database=DotNetBackendTemplate;");
        }

        public DbSet<SomeFeatureEntity> SomeFeatureEntities { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<AccountOperationClaim> AccountOperationClaims { get; set; }
    }
}

