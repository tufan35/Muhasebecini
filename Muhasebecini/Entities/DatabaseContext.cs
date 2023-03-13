using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Muhasebecini.Entities
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public virtual DbSet<AccountantInfo> AccountantInfos { get; set; }
        public virtual DbSet<CommendInfo> CommendInfos { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }


        public DatabaseContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured) { }

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("MsSQLConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountantInfo>(entity =>
            {
                entity.ToTable("Accountant_Info");

                entity.HasComment("Muhasebeci Bilgileri");

                entity.Property(p => p.Id)
                      .UseIdentityColumn();

                entity.Property(p => p.Name)
                      .HasColumnName("Name")
                      .IsRequired();

                entity.Property(p => p.Surname)
                      .HasColumnName("Surname")
                      .IsRequired();

                entity.Property(p => p.Phone)
                      .HasColumnName("Phone")
                      .IsRequired();

                entity.Property(p => p.Address)
                      .HasColumnName("Address")
                      .IsRequired();

                entity.Property(p => p.Image)
                      .HasColumnName("Image")
                      .HasColumnType("VARBINARY(MAX)")
                      .IsRequired(false);
            });


            modelBuilder.Entity<CustomerInfo>(entity =>
            {

                entity.ToTable("Customer_Info");

                entity.HasComment("Müşteri Bilgileri");

                entity.Property(p => p.Id)
                      .UseIdentityColumn();

                entity.Property(p => p.Name)
                      .HasColumnName("Name")
                      .IsRequired();

                entity.Property(p => p.Surname)
                      .HasColumnName("Surname")
                      .IsRequired();
            });


            modelBuilder.Entity<CommendInfo>(entity =>
            {

                entity.ToTable("Commend_Info");

                entity.HasComment("Yorum Bilgileri");

                entity.Property(p => p.Id)
                      .UseIdentityColumn();


                entity.Property(p => p.Commend)
                      .HasColumnName("Commend")
                      .IsRequired(false);


                entity.HasOne(d => d.AccountantInfo)
                      .WithMany(p => p.CommendInfos)
                      .HasForeignKey(d => d.AccountantId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Accountant_Id_Fkey");

                entity.HasOne(d => d.CustomerInfo)
                      .WithMany(p => p.CommendInfos)
                      .HasForeignKey(d => d.CustomerId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Customer_Id_Fkey");
            });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
