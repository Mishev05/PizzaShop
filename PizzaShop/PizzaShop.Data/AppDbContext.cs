namespace PizzaShop1.Data
{
    using Microsoft.EntityFrameworkCore;
    using PizzaShop1.Models;
    public class AppDbContext:DbContext
    {
        private const string connectionString = @"Server=LENOVO-DESKSTOP\MSSQLSERVER02; Initial Catalog=PizzaShopEfNew; Integrated Security=true; Trusted_Connection=true; TrustServerCertificate=true;";
        public virtual DbSet<PizzaShop> PizzaShops { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<MenuItems> MenuItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItems>(option =>
            {
                option.HasKey(x => new { x.MenuId, x.ItemId });
            });
            modelBuilder.Entity<PizzaShop>(option =>
            {
                option.Property(x => x.Name)
                    .IsRequired();

                option.Property(x => x.Location)
                    .IsRequired();
            });
            modelBuilder.Entity<Customer>(option =>
            {
                option.Property(x => x.Name)
                   .IsRequired();

                option.Property(x => x.PhoneNumber)
                .IsRequired();
            });
            modelBuilder.Entity<Menu>(option =>
            {

                option.HasOne(x => x.PizzaShop)
                    .WithMany(x => x.Menus)
                    .HasForeignKey(x => x.PizzaShopId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Item>(option =>
            {
                option.Property(x => x.Name)
                .IsRequired();
            });
        }
    }
}
