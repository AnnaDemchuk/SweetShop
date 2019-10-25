namespace Shop.DAL.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderPosition> OrderPosition { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPrice> ProductPrice { get; set; }
        public virtual DbSet<StatusOrder> StatusOrder { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<TasteCategory> TasteCategory { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategory)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.TasteCategory)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.DeliveryPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Delivery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.ManufacturerPhone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderPosition)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderPosition>()
                .Property(e => e.OrderPosPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderPosition)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Photo)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductPrice)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductPrice>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<StatusOrder>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.StatusOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Unit)
                .WillCascadeOnDelete(false);
        }
    }
}
