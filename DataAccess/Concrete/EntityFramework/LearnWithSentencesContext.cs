using System;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	public class LearnWithSentencesContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string myServerAddress = MyConnectionString.ServerAddress;
            string myDatabase = MyConnectionString.Database;
            string myUsername = MyConnectionString.Username;
            string myPassword = MyConnectionString.Password;
            optionsBuilder.UseSqlServer("Server="+myServerAddress+";Database="+myDatabase+";User="+myUsername+";Password="+myPassword+";Encrypt=False;");
        }

        public DbSet<SomeFeatureEntity> SomeFeatureEntities { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<AccountOperationClaim> AccountOperationClaims { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<StudySet> StudySets { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Definition> Definitions { get; set; }
    }
}

