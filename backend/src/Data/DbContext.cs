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
        public DbSet<ToDoListAPI.Models.Task> Tasks { get; set; }

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
                .HasKey(l => l.ListId);
            modelBuilder.Entity<List>()
                .Property(l => l.ListId)
                .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<List>()
                .Property(l => l.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<List>()
                .Property(l => l.Description).HasMaxLength(1000);
            modelBuilder.Entity<List>()
                .Property(l => l.UserId).IsRequired();
            modelBuilder.Entity<List>()
                .Property(l => l.CreatedAt).IsRequired();
            modelBuilder.Entity<List>()
                .Property(l => l.UpdatedAt);
        }

        private void ConfigureUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<User>()
                .Property(u => u.Username).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<User>()
                .Property(u => u.Email).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>()
                .Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Role).IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Status).IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.UpdatedAt);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username).IsUnique();
        }

        private void ConfigureTaskEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .ToTable("Tasks")
                .HasKey(t => t.TaskId);
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.TaskId)
                .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.Description).HasMaxLength(1000);
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.DueDate);
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.Status).IsRequired();
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.ListId).IsRequired();
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.UserId).IsRequired();
            modelBuilder.Entity<Models.Task>()
                .HasIndex(t => t.DueDate);
            modelBuilder.Entity<Models.Task>()
                .Property(t => t.RowVersion)
                .IsRowVersion();
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Lists)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<List>()
                .HasMany(l => l.Tasks)
                .WithOne(t => t.List)
                .HasForeignKey(t => t.ListId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}