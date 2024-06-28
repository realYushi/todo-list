using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options)
            : base(options)
        {
        }

        public DbSet<List> Lists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureListEntity(modelBuilder);
            ConfigureUserEntity(modelBuilder);
            ConfigureTaskEntity(modelBuilder);
            ConfigureRelationships(modelBuilder);
        }

        private void ConfigureListEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>()
                .ToTable("Lists")
                .HasKey(l => l.Id);
            modelBuilder.Entity<List>()
                .Property(l => l.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<List>()
                .Property(l => l.Description).HasMaxLength(1000);
            modelBuilder.Entity<List>()
                .Property(l => l.UserId).IsRequired();
        }

        private void ConfigureUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Username).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<User>()
                .Property(u => u.Email).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>()
                .Property(u => u.Role).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(u => u.Status).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();
        }

        private void ConfigureTaskEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .ToTable("Tasks")
                .HasKey(t => t.Id);
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.Description).HasMaxLength(1000);
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.DueDate).IsRequired();
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.Status).IsRequired();
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.ListId).IsRequired();
            modelBuilder.Entity<Models.Task>()
                .HasIndex(t => t.DueDate);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .HasOne<List>().WithMany().HasForeignKey(t => t.ListId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany<List>(u => u.Lists).WithOne(l => l.User).HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<List>()
                .HasMany<Models.Task>(l => l.Tasks).WithOne(t => t.List).HasForeignKey(t => t.ListId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}