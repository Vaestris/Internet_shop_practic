using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Internet_shop_practic.Models;
using System.Text.Json;
using System.IO;

namespace Internet_shop_practic
{
    public class ProgramContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public ProgramContext()
        {
            Database.EnsureCreated();
        }

        private string connectionstring = File.ReadAllText("appconfig.json").Substring(File.ReadAllText("appconfig.json").IndexOf("Server"), File.ReadAllText("appconfig.json").LastIndexOf('"') - File.ReadAllText("appconfig.json").IndexOf("Server"));
        
        //private const string connectionstring = @"Server=DESKTOP-8HTVICI;Database=internet_sop_test;Trusted_Connection=True";

        //подключние к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionstring);
        }

        //Создание модели
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasKey(u => u.Id);

            modelBuilder.Entity<Order>().HasKey(u => u.Id);
            modelBuilder.Entity<Order>().HasOne(p => p.Customer).WithMany(b => b.Orders).HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<Order>().HasOne(p => p.Product).WithMany(b => b.Orders).HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Product>().HasKey(u => u.Id);

            modelBuilder.Entity<Delivery>().HasKey(u => u.Id);
            //modelBuilder.Entity<delivery>().HasOne(p => p.order).WithOne(b => b.delivery).HasForeignKey(p => p.orderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}