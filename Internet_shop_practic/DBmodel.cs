using Microsoft.EntityFrameworkCore;
using Internet_shop_practic.Models;
using Microsoft.Extensions.Configuration;

namespace Internet_shop_practic
{
    /// <summary>
    /// Полкючение к SQL серверу и создание/реадктирвоанеи базы данных
    /// </summary>
    public class DBmodel : DbContext
    {      
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DBmodel()
        {
            Database.EnsureCreated();
        }
        private static string connectionstring;
        /// <summary>
        /// Получение строки подключения 
        /// </summary>
        /// <param name="configuration"></param>
        public DBmodel(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("DefaultConnection");
            Database.EnsureCreated();
        }

        /// <summary>
        /// Конфигурация подключения к SQL серверу
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionstring);
        }

        /// <summary>
        /// Создание базы данных и установка настроек связей и таблиц
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasKey(u => u.Id);

            modelBuilder.Entity<Customer>().Property(b => b.Phone_number).IsRequired();
            modelBuilder.Entity<Customer>().Property(b => b.FirstName).IsRequired();
            modelBuilder.Entity<Customer>().Property(b => b.LastName).IsRequired();

            modelBuilder.Entity<Order>().HasKey(u => u.Id);

            modelBuilder.Entity<Order>().HasOne(p => p.Customer).WithMany(b => b.Orders).HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<Order>().HasOne(p => p.Product).WithMany(b => b.Orders).HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Order>().Property(b => b.TotalPrice).IsRequired();
            modelBuilder.Entity<Order>().Property(b => b.Address).IsRequired();

            modelBuilder.Entity<Product>().HasKey(u => u.Id);

            modelBuilder.Entity<Product>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(b => b.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(b => b.Booked).IsRequired();

            modelBuilder.Entity<Delivery>().HasKey(u => u.Id);

            modelBuilder.Entity<Delivery>().Property(b => b.Shipment).IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}