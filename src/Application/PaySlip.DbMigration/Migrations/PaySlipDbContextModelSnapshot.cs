﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaySlip.Domain.Infrastructure;

namespace PaySlip.DbMigration.Migrations
{
    [DbContext(typeof(PaySlipDbContext))]
    partial class PaySlipDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PaySlip.Domain.Model.TaxRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<decimal>("Over")
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("Over");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("Rate");

                    b.Property<decimal>("UpTo")
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("UpTo");

                    b.HasKey("Id");

                    b.ToTable("TaxRates");
                });
#pragma warning restore 612, 618
        }
    }
}