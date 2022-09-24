using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CustomerAccount.Models
{
    public partial class RetailBankingContext : DbContext
    {
        public RetailBankingContext()
        {
        }

        public RetailBankingContext(DbContextOptions<RetailBankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.9.246.162,4022;Database=RetailBanking;User ID=sa;pwd=CreateFile();");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Address");

                entity.Property(e => e.CustomerDob)
                    .HasColumnType("datetime")
                    .HasColumnName("Customer_DOB");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.CustomerPan)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Customer_PAN");
            });

            modelBuilder.Entity<CustomerAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__Customer__B19E45C9D0BD7FA2");

                entity.ToTable("CustomerAccount");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Account_type");

                entity.Property(e => e.ChequeNo).HasColumnName("CHEQUE_NO");

                entity.Property(e => e.ClosingBalance).HasColumnName("CLOSING_BALANCE");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.Deposit).HasColumnName("DEPOSIT");

                entity.Property(e => e.Narration)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NARRATION");

                entity.Property(e => e.ValueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("VALUE_DATE");

                entity.Property(e => e.Withdrawal).HasColumnName("WITHDRAWAL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
