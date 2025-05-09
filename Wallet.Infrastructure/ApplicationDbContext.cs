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

        public DbSet<MovementHistory> MovementsHistory { get; set; }
 
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


            modelBuilder.Entity<Billetera>(entity =>
            {
                entity.HasKey(w => w.id);
                entity.Property(w => w.balance).HasPrecision(18, 2);

                entity.HasMany(w => w.movements)
                      .WithOne(m => m.wallet)
                      .HasForeignKey(m => m.walletId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<MovementHistory>(entity =>
            {
                entity.HasKey(m => m.id);
                entity.Property(m => m.amount).HasPrecision(18, 2);
                entity.Property(m => m.type).IsRequired();
            });


            modelBuilder.Entity<Transference>(entity =>
            {
                entity.HasKey(t => t.id);
                entity.Property(t => t.amount).HasPrecision(18, 2);

                entity.HasOne(t => t.sourceWallet)
                      .WithMany()
                      .HasForeignKey(t => t.sourceWalletId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.destinationWallet)
                      .WithMany()
                      .HasForeignKey(t => t.destinationWalletId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
