using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.DataModels;

// to create database & migration
namespace Project.Api.Controllers
{
    public class MyDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }




        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<User>().HasData(new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Username = "Admin",
                Role = "Admin",
                Password="1234",
                UserId =100,

            });



        }


    }

}