using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Entities;

namespace Wallet.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Billetera> Billeteras { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().ToTable("Usuarios");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.documentId).IsUnique();
                entity.Property(u => u.documentId).IsRequired();

                entity.HasOne(u => u.Billetera)
                      .WithOne(b => b.User)
                      .HasForeignKey<Billetera>(b => b.documentId)
                      .HasPrincipalKey<User>(u => u.documentId);
            });

            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsuariosRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsuariosClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuariosLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RolesClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuariosTokens");

            modelBuilder.Entity<Billetera>()
            .Property(b => b.balance)
            .HasPrecision(18, 2);

        }
    }
}
