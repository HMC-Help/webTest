using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebTest.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Program.Configuration.GetConnectionString("SchoolDatabase"));
            }
        }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.GradeId);
                entity.Property(e => e.GradePointTotal).HasColumnType("money");

                entity.HasMany<Student>(g => g.Students)
                   .WithOne(s => s.Grade)
                   .HasForeignKey(s => s.GradeId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.TotalPoints).HasColumnType("money");

                entity.HasOne<Grade>(g => g.Grade)
                   .WithMany(s => s.Students)
                   .HasForeignKey(s => s.GradeId);

                entity.HasMany<Transaction>(g => g.Transactions)
                   .WithOne(s => s.Student)
                   .HasForeignKey(s => s.StudentId);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);
                entity.Property(e => e.TransactionDate).HasColumnType("datetime");
                entity.Property(e => e.Points).HasColumnType("money");

                entity.HasOne<Student>(g => g.Student)
                   .WithMany(s => s.Transactions)
                   .HasForeignKey(s => s.StudentId);

            });
        }
    }
}
