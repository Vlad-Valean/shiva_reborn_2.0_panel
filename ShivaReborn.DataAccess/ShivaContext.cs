using Microsoft.EntityFrameworkCore;
using ShivaReborn.DataAccess.Models;
using System.Data;
namespace ShivaReborn.DataAccess
{
    public class ShivaContext : DbContext
    {
        public ShivaContext(DbContextOptions<ShivaContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Floor> floors { get; set; }
        public DbSet<Place> places { get; set; }
        public DbSet<Building> buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Place>().ToTable("Places");
            modelBuilder.Entity<Floor>().ToTable("Floors");
            modelBuilder.Entity<Building>().ToTable("Buildings");
        }



    }
}