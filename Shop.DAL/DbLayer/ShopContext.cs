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

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDetail> Salepos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>()
                .Property(e => e.GoodName)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Good>()
                .Property(e => e.GoodCount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.Salepos)
                .WithRequired(e => e.Good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Summa)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sale>()
                .HasMany(e => e.Salepos)
                .WithRequired(e => e.Sale)
                .WillCascadeOnDelete(false);
        }

      

        //  public System.Data.Entity.DbSet<Shop.BLL.Models.GoodDTO> GoodDTOes { get; set; }
    }
}
