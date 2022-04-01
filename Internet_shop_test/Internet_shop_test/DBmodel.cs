using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Internet_shop_test
{
    public class ProgramContext : DbContext
    {
         public DbSet<Customer> customers { get; set; }
         public DbSet<Order> orders { get; set; }
         public DbSet<Product> products { get; set; }
         public DbSet<Delivery> deliveries { get; set; }
        public ProgramContext()
        {
            Database.EnsureCreated();
        }

        //private const string connectionstring = @"Server=.\MSSQLSERVER;Database=internet_shop_test;Trusted_Connection=True;";
        private const string connectionstring = @"Server=DESKTOP-8HTVICI;Database=internet_sop_test;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasKey(u => u.id);

            modelBuilder.Entity<Order>().HasKey(u => u.id);
            modelBuilder.Entity<Order>().HasOne(p => p.customer).WithMany(b => b.Orders).HasForeignKey(p => p.customerId);
            modelBuilder.Entity<Order>().HasOne(p => p.product).WithMany(b => b.Orders).HasForeignKey(p => p.productId);

            modelBuilder.Entity<Product>().HasKey(u => u.id);

            modelBuilder.Entity<Delivery>().HasKey(u => u.id);
            //modelBuilder.Entity<delivery>().HasOne(p => p.order).WithOne(b => b.delivery).HasForeignKey(p => p.orderId);

            //modelBuilder.Entity<Department>().Property(t => t.Name).IsRequired();
            //modelBuilder.Entity<customer>().HasNoKey();
            //modelBuilder.Entity<order>().HasNoKey();
            //modelBuilder.Entity<product>().HasNoKey();
            //modelBuilder.Entity<product>().Property(et => et.product_number).ValueGeneratedNever();
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }


    public class Customer
    {
        public int id { get; set; }
        public string phone_number { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string company { get; set; }

        public List<Order> Orders { get; set; }

    }
    public class Order
    {
        public int id { get; set; }

        public string adress { get; set; }

        public int customerId { get; set; }//внещний ключ
        public int productId { get; set; }//внещний ключ


        public Customer customer { get; set; }//навигационные свойство 
        public Product product { get; set; }//навигационные свойство 


        public Delivery delivery { get; set; }

    }
    public class Product
    {
        public int id { get; set; }
        public int product_number { get; set; }
        public int existence { get; set; }
        public string name { get; set; }

        public List<Order> Orders { get; set; }

    }
    public class Delivery
    {
        public int id { get; set; }
        public int order_number { get; set; }
        public bool shipment { get; set; }
        public bool issued { get; set; }
        public bool delivered { get; set; }
        public DateTime time { get; set; }

        public int orderId { get; set; }//внещний ключ

        public Order order { get; set; }//навигационные свойство 

    }
}