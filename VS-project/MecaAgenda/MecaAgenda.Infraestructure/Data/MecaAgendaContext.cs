using System;
using System.Collections.Generic;
using MecaAgenda.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MecaAgenda.Infraestructure.Data;

public partial class MecaAgendaContext : DbContext
{
    public MecaAgendaContext(DbContextOptions<MecaAgendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointments> Appointments { get; set; }

    public virtual DbSet<BillItems> BillItems { get; set; }

    public virtual DbSet<Bills> Bills { get; set; }

    public virtual DbSet<BranchSchedules> BranchSchedules { get; set; }

    public virtual DbSet<Branches> Branches { get; set; }

    public virtual DbSet<Categories> Categories { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<ScheduleExceptions> ScheduleExceptions { get; set; }

    public virtual DbSet<Services> Services { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointments>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA267DA0FE5");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Bill).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Appointments_Bill");

            entity.HasOne(d => d.Branch).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Branch");

            entity.HasOne(d => d.Client).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Client");

            entity.HasOne(d => d.Service).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Service");
        });

        modelBuilder.Entity<BillItems>(entity =>
        {
            entity.HasKey(e => e.BillItemId).HasName("PK__BillItem__47605AD52F9AF742");

            entity.Property(e => e.BillItemId).HasColumnName("BillItemID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Bill).WithMany(p => p.BillItems)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillItems_Bill");

            entity.HasOne(d => d.Product).WithMany(p => p.BillItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillItems_Product");
        });

        modelBuilder.Entity<Bills>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bills__11F2FC4A87B1E602");

            entity.ToTable(tb => tb.HasTrigger("trg_DeleteBill"));

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Branch).WithMany(p => p.Bills)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bills_Branch");

            entity.HasOne(d => d.Client).WithMany(p => p.Bills)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bills_Client");
        });

        modelBuilder.Entity<BranchSchedules>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__BranchSc__9C8A5B69E72E0EA3");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.HasOne(d => d.Branch).WithMany(p => p.BranchSchedules)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchSchedules_Branch");
        });

        modelBuilder.Entity<Branches>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__Branches__A1682FA565867959");

            entity.ToTable(tb => tb.HasTrigger("trg_DeleteBranch"));

            entity.HasIndex(e => e.Phone, "UQ__Branches__5C7E359EE368791B").IsUnique();

            entity.HasIndex(e => e.Address, "UQ__Branches__7D0C3F32F2FE57E4").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Branches__A9D10534CE04BF4E").IsUnique();

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Categories>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B3D88EF86");

            entity.ToTable(tb => tb.HasTrigger("trg_DeleteCategory"));

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDD31C4FB4");

            entity.ToTable(tb => tb.HasTrigger("trg_DeleteProduct"));

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Category");
        });

        modelBuilder.Entity<ScheduleExceptions>(entity =>
        {
            entity.HasKey(e => e.ExceptionId).HasName("PK__Schedule__26981DA80C5B3632");

            entity.Property(e => e.ExceptionId).HasColumnName("ExceptionID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Reason).HasMaxLength(255);
            entity.Property(e => e.ServicesAffected).HasMaxLength(255);

            entity.HasOne(d => d.Branch).WithMany(p => p.ScheduleExceptions)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ScheduleExceptions_Branch");
        });

        modelBuilder.Entity<Services>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__C51BB0EA7E36632D");

            entity.ToTable(tb => tb.HasTrigger("trg_DeleteService"));

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.MaterialsNeeded).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ToolsRequired).HasMaxLength(255);
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC02A94976");

            entity.ToTable(tb => tb.HasTrigger("trg_DeleteUser"));

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053417CD405D").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(20);

            entity.HasOne(d => d.Branch).WithMany(p => p.Users)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Users_Branch");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
