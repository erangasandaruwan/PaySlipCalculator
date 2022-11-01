using Microsoft.EntityFrameworkCore;
using PaySlip.Domain.Model;

namespace PaySlip.Domain.Infrastructure
{
    public class PaySlipDbContext : DbContext
    {
        public PaySlipDbContext(DbContextOptions<PaySlipDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<TaxRate> TaxRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaySlipDbContext).Assembly);

            modelBuilder.Entity<TaxRate>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();

                entity.Property(s => s.Over)
                    .HasColumnName("Over")
                    .HasColumnType("decimal(12, 2)")
                    .IsRequired();

                entity.Property(s => s.UpTo)
                    .HasColumnName("UpTo")
                    .HasColumnType("decimal(12, 2)")
                    .IsRequired();

                entity.Property(s => s.Rate)
                    .HasColumnName("Rate")
                    .HasColumnType("decimal(5, 2)")
                    .IsRequired();
            });

        }
    }
}
