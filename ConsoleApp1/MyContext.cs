using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class MyContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseInMemoryDatabase("ConsoleApp1");

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
