using AuthService.Domain.Entities;
using AuthService.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.Abstracts;

namespace AuthService.Persistence.Repository.EntityFramework.Context
{
    public class AuthDbContext(DbContextOptions<AuthDbContext> opt) : DbContext(opt)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationClaim>().HasData(
                new OperationClaim { Id = (int)OperationClaimType.Customer, Name = OperationClaimType.Customer.ToString(), CreatedDate = DateTime.Now },
                new OperationClaim { Id = (int)OperationClaimType.Admin, Name = OperationClaimType.Admin.ToString(), CreatedDate = DateTime.Now }
            );

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2(0)");

                    modelBuilder.Entity(entityType.ClrType).Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2(0)");
                }
            }
        }
    }
}
