using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudDemo.Data.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmployeesTerritories> EmployeesTerritories { get; set; }
        public virtual DbSet<InternationalOrders> InternationalOrders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PagingTest> PagingTest { get; set; }
        public virtual DbSet<PreviousEmployees> PreviousEmployees { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Territories> Territories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=..\\CrudDemo\\northwind.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.HasIndex(e => e.CategoryName);

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnType("nvarchar(15)");

                entity.Property(e => e.Description).HasColumnType("nvarchar");

                entity.Property(e => e.Picture).HasColumnType("varbinary");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.HasIndex(e => e.City);

                entity.HasIndex(e => e.CompanyName);

                entity.HasIndex(e => e.PostalCode);

                entity.HasIndex(e => e.Region);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("nchar(5)");

                entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

                entity.Property(e => e.City).HasColumnType("nvarchar(15)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar(40)");

                entity.Property(e => e.ContactName).HasColumnType("nvarchar(30)");

                entity.Property(e => e.ContactTitle).HasColumnType("nvarchar(30)");

                entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Fax).HasColumnType("nvarchar(24)");

                entity.Property(e => e.Phone).HasColumnType("nvarchar(24)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar(15)");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.HasIndex(e => e.LastName);

                entity.HasIndex(e => e.PostalCode);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Extension).HasColumnType("nvarchar(4)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nvarchar(10)");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.HomePhone).HasColumnType("nvarchar(24)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nvarchar(20)");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PhotoPath).HasColumnType("nvarchar(255)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Title).HasColumnType("nvarchar(30)");

                entity.Property(e => e.TitleOfCourtesy).HasColumnType("nvarchar(25)");
            });

            modelBuilder.Entity<EmployeesTerritories>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.TerritoryId });

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesTerritories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.EmployeesTerritories)
                    .HasForeignKey(d => d.TerritoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<InternationalOrders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomsDescription)
                    .IsRequired()
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.ExciseTax)
                    .IsRequired()
                    .HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.InternationalOrders)
                    .HasForeignKey<InternationalOrders>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderDetails_OrdersOrder_Details");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_OrderDetails_ProductsOrder_Details");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UnitPrice)
                    .IsRequired()
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_Orders_CustomersOrders");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_Orders_EmployeesOrders");

                entity.HasIndex(e => e.OrderDate);

                entity.HasIndex(e => e.ShipPostalCode);

                entity.HasIndex(e => e.ShippedDate);

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("nchar(5)");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress).HasColumnType("nvarchar(60)");

                entity.Property(e => e.ShipCity).HasColumnType("nvarchar(15)");

                entity.Property(e => e.ShipCountry).HasColumnType("nvarchar(15)");

                entity.Property(e => e.ShipName).HasColumnType("nvarchar(40)");

                entity.Property(e => e.ShipPostalCode).HasColumnType("nvarchar(10)");

                entity.Property(e => e.ShipRegion).HasColumnType("nvarchar(15)");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<PagingTest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PreviousEmployees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Extension).HasColumnType("nvarchar(4)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nvarchar(10)");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.HomePhone).HasColumnType("nvarchar(24)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nvarchar(20)");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PhotoPath).HasColumnType("nvarchar(255)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Title).HasColumnType("nvarchar(30)");

                entity.Property(e => e.TitleOfCourtesy).HasColumnType("nvarchar(25)");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_Products_CategoriesProducts");

                entity.HasIndex(e => e.ProductName);

                entity.HasIndex(e => e.SupplierId)
                    .HasName("IX_Products_SuppliersProducts");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Discontinued)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("nvarchar(40)");

                entity.Property(e => e.QuantityPerUnit).HasColumnType("nvarchar(20)");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitsInStock)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitsOnOrder)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.Property(e => e.RegionId)
                    .HasColumnName("RegionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RegionDescription)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.HasIndex(e => e.CompanyName);

                entity.HasIndex(e => e.PostalCode);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

                entity.Property(e => e.City).HasColumnType("nvarchar(15)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar(40)");

                entity.Property(e => e.ContactName).HasColumnType("nvarchar(30)");

                entity.Property(e => e.ContactTitle).HasColumnType("nvarchar(30)");

                entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Fax).HasColumnType("nvarchar(24)");

                entity.Property(e => e.HomePage).HasColumnType("ntext");

                entity.Property(e => e.Phone).HasColumnType("nvarchar(24)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar(15)");
            });

            modelBuilder.Entity<Territories>(entity =>
            {
                entity.HasKey(e => e.TerritoryId);

                entity.Property(e => e.TerritoryId)
                    .HasColumnName("TerritoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.TerritoryDescription)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
