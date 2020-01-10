using ComProvis.CSP.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComProvis.CSP.Persistance
{
    public class CspDbContext : DbContext, ICspDbContext
    {
        public CspDbContext()
        {
        }

        public CspDbContext(DbContextOptions<CspDbContext> options) : base(options)
        {
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters) => await Database.ExecuteSqlCommandAsync(sql, parameters);
        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Margin).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Customer");

                entity.HasOne(d => d.Role)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

        }

    }
}
