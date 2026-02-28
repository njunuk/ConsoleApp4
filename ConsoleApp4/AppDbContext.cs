using ConsoleApp4.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIntro
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Database=newdbbUpdate;TrustServerCertificate=true";
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public AppDbContext() 
        { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}