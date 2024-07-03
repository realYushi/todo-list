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
            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "user1",
                    Username = "johndoe",
                    Email = "john.doe@example.com",
                    Role = "Admin",
                    Status = "Active"
                }
            );

            modelBuilder.Entity<List>().HasData(
                new List
                {
                    Id = "list1",
                    Name = "Home Tasks",
                    Description = "Tasks to do at home.",
                    UserId = "user1"
                },
                new List
                {
                    Id = "list2",
                    Name = "Work Tasks",
                    Description = "Tasks to do at work.",
                    UserId = "user1"
                }
            );

            modelBuilder.Entity<Models.Task>().HasData(
                new Models.Task
                {
                    Id = "task1",
                    Title = "Wash dishes",
                    Description = "Wash all the dishes from dinner.",
                    DueDate = DateTime.Now.AddDays(1),
                    Status = Models.Task.StatusEnum.PendingEnum,
                    ListId = "list1"
                },
                new Models.Task
                {
                    Id = "task2",
                    Title = "Prepare presentation",
                    Description = "Prepare the monthly performance presentation.",
                    DueDate = DateTime.Now.AddDays(3),
                    Status = Models.Task.StatusEnum.InProgressEnum,
                    ListId = "list2"
                }
            );
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