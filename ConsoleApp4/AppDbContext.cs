using ConsoleApp4.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIntro
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=VICTUS_LAPTOP\MSQLSERVER;Database=newdbbUpdate;TrustServerCertificate=true";
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Kafedra> Kafedras { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public AppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentGroup>().ToView("vw_StudentGroups").HasNoKey();
            //teacher
            modelBuilder.Entity<Teacher>(x =>
            {
                x.Property(x => x.Salary).HasColumnType("decimal(8,2)").HasDefaultValue(25000);
                x.Property(x => x.FirstName).HasMaxLength(50);
                x.Property(x => x.LastName).HasMaxLength(50);
                x.ToTable(x => x.HasCheckConstraint("CK_Salary>0", "[Salary] > 0"));
                x.HasCheckConstraint("CK_Teacher_FirstName_NotEmpty", "[FirstName] <> ''");
                x.HasCheckConstraint("CK_Teacher_LastName_NotEmpty", "[LastName] <> ''");
            });
            //group
            modelBuilder.Entity<Group>(x =>
            {
                x.Property(x => x.Name).HasMaxLength(10);
                x.ToTable(t => t.HasCheckConstraint("CK_Group_Name_NotEmpty", "[Name] <> ''"));
            });
            //student
            modelBuilder.Entity<Student>(x =>
            {
                x.Property(x => x.FirstName).HasMaxLength(50);
                x.Property(x => x.LastName).HasMaxLength(50);
                x.HasIndex(x => x.Email).IsUnique();
                x.Property(x => x.Scholarship).HasColumnType("decimal(6,2)");
                x.HasCheckConstraint("CK_Student_FirstName_NotEmpty", "[FirstName] <> ''");
                x.HasCheckConstraint("CK_Student_LastName_NotEmpty", "[LastName] <> ''");
                x.HasCheckConstraint("CK_Student_Email_At", "[Email] LIKE '%@%'");
            });
            modelBuilder.Entity<Passport>(x =>
            {
                x.Property(x => x.Number).HasMaxLength(9);
                x.HasIndex(x => x.Number).IsUnique();
                x.HasCheckConstraint("CK_Passport_Number_9Digits", "LEN([Number]) = 9 AND [Number] NOT LIKE '%[^0-9]%'");
            });
            modelBuilder.Entity<Subject>(x =>
            {
                x.Property(x => x.Name).HasMaxLength(50);
                x.Property(x => x.Description).IsRequired(false);
                x.HasCheckConstraint("CK_Subject_Name_NotEmpty", "[Name] <> ''");
            });
            modelBuilder.Entity<Kafedra>(x =>
            {
                x.Property(x => x.Name).HasMaxLength(50);
                x.HasCheckConstraint("CK_Kafedra_Name_NotEmpty", "[Name] <> ''");
            });
        }
    }
}