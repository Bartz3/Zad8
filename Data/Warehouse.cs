#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zad8.Models;

namespace Zad8.Data
{
    public class Warehouse : DbContext
    {
        public Warehouse (DbContextOptions<Warehouse> options)
            : base(options)
        {
        }
        public DbSet<Zad8.Models.Category> Category { get; set; }
        public DbSet<Zad8.Models.Commodity> Commodity { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commodity>().ToTable("Commodity");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
