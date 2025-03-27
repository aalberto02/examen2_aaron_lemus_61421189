using examen2_aaron_lemus_61421189.Models;
using Microsoft.EntityFrameworkCore;

namespace examen2_aaron_lemus_61421189.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Models.Task>().ToTable("Task");

            //modelBuilder.Entity<User>().Property(u => u.Name).HasColumnName("name");
            //modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email");
            //modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("password");
            //modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasColumnName("created_at");

            modelBuilder.Entity<Models.Task>().Property(u => u.Tittle).HasColumnName("title");
            modelBuilder.Entity<Models.Task>().Property(u => u.Description).HasColumnName("description");
            modelBuilder.Entity<Models.Task>().Property(u => u.CreatedAt).HasColumnName("created_at");

        }

    }
}
