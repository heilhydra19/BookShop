using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<ImportDetail> ImportDetails { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Author>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Author");
        //        entity.Property(p => p.CreateAt)
        //              .HasDefaultValueSql("CURRENT_TIMESTAMP");
        //    });
        //    modelBuilder.Entity<Category>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Category");
        //    });
        //    modelBuilder.Entity<Customer>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Customer");
        //        entity.Property(p => p.CreateAt)
        //              .HasDefaultValueSql("CURRENT_TIMESTAMP");
        //        entity.HasOne(c => c.EmployeeNavigation)
        //            .WithMany(c => c.Customers)
        //            .HasForeignKey(e => e.EmloyeeId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_Customer_Employee");
        //    });
        //    modelBuilder.Entity<Supplier>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Suplier");
        //        entity.Property(p => p.CreateAt)
        //              .HasDefaultValueSql("CURRENT_TIMESTAMP");
        //    });
        //    modelBuilder.Entity<Role>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Role");
        //    });
        //    modelBuilder.Entity<Publisher>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Publisher");
        //        entity.Property(p => p.CreateAt)
        //              .HasDefaultValueSql("CURRENT_TIMESTAMP");
        //    });
        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Employee");
        //        entity.Property(p => p.CreateAt)
        //              .HasDefaultValueSql("CURRENT_TIMESTAMP");

        //        entity.HasOne(c => c.RoleNaviagtion)
        //            .WithMany(c => c.Employees)
        //            .HasForeignKey(e => e.RoleId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_Employee_Role");
        //    });
        //    modelBuilder.Entity<Import>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Import");
        //        entity.Property(p => p.CreateAt)
        //              .HasDefaultValueSql("CURRENT_TIMESTAMP");

        //        entity.HasOne(c => c.SupplierNavigation)
        //            .WithMany(c => c.Imports)
        //            .HasForeignKey(e => e.SupplierId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_Import_Supplier");
        //        entity.HasOne(c => c.EmployeeNavigation)
        //            .WithMany(c => c.Imports)
        //            .HasForeignKey(e => e.EmployeeId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_Import_Employee");
        //    });
        //    modelBuilder.Entity<Bill>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Bill");
        //        entity.Property(p => p.CreateAt)
        //              .HasDefaultValueSql("CURRENT_TIMESTAMP");

        //        entity.HasOne(c => c.CustomerNavigation)
        //            .WithMany(c => c.Bills)
        //            .HasForeignKey(e => e.CustomerId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_Bill_Customer");

        //        entity.HasOne(c => c.EmployeeNavigation)
        //            .WithMany(c => c.Bills)
        //            .HasForeignKey(e => e.EmployeeId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_Bill_Employee");
        //    });
        //    modelBuilder.Entity<Book>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //              .HasName("pk_Book");

        //        entity.HasOne(c => c.CategoryNavigation)
        //            .WithMany(c => c.Books)
        //            .HasForeignKey(e => e.CategoryId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_Book_Category");
        //        entity.HasOne(c => c.PublisherNavigation)
        //           .WithMany(c => c.Books)
        //           .HasForeignKey(e => e.PublisherId)
        //           .OnDelete(DeleteBehavior.ClientSetNull)
        //           .HasConstraintName("fk_Book_Publisher");
        //    });
        //    modelBuilder.Entity<BillDetail>(entity =>
        //    {
        //        entity.HasKey(e => new { e.BillId, e.BookId });

        //        entity.HasOne(e => e.BillNavigation)
        //        .WithMany(e => e.BillDetails)
        //            .HasForeignKey(e => e.BillId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_BillDetail_Bill");
        //        entity.HasOne(e => e.BookNavigation)
        //        .WithMany(e => e.BillDetails)
        //            .HasForeignKey(e => e.BookId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_BillDetail_Book");
        //    });
        //    modelBuilder.Entity<ImportDetail>(entity =>
        //    {
        //        entity.HasKey(e => new { e.BookId, e.ImportId });

        //        entity.HasOne(e => e.ImportNavigation)
        //        .WithMany(e => e.ImportDetails)
        //            .HasForeignKey(e => e.ImportId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_ImportDetail_Import");
        //        entity.HasOne(e => e.BookNavigation)
        //        .WithMany(e => e.ImportDetails)
        //            .HasForeignKey(e => e.BookId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_ImportDetail_Book");
        //    });
        //}
    }
}