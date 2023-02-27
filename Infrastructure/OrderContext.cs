using Domain.Common;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        {
        }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }


        public DbSet<Order> Order { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Contractor> Contractor { get; set; }
        public DbSet<OrderDetalis> OrderDetalis { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateBy = "1"; // Change to GetUserId when make autoryzation;
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdateBy = "2";
                        entry.Entity.UpdateDate = DateTime.Now;
                        break;
                }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =postgres;Password=Immolation@138;Server=192.168.250.50;Port=5432;Database=Hades;Integrated Security=true;Pooling=true;")
                .UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(order =>
                  {
                      order.HasMany(o => o.OrderDetalis)
                       .WithOne(orderdetalis => orderdetalis.Order)
                       .HasForeignKey(o => o.OrderId);
                      order.HasOne(c => c.Contractor)
                      .WithMany(contractor => contractor.Orders)
                      .HasForeignKey(c => c.ContractorId);
                  });
            modelBuilder.Entity<OrderDetalis>(orderdetalis =>
            {
                orderdetalis.HasOne(a => a.Article).WithMany(a => a.OrderDetalis).HasForeignKey(a => a.ArticleId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
