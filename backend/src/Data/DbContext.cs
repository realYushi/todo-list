using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ListModel> Lists { get; set; }
        public DbSet<UserModel> Users { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Task model
            modelBuilder.Entity<TaskModel>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.DueDate).HasColumnType("date");
                entity.HasOne(d => d.List)
                    .WithMany(p => (IEnumerable<TaskModel>)p.Tasks)
                    .HasForeignKey(d => d.ListId);
            });

            // Configure the List model
            modelBuilder.Entity<ListModel>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.UserId);
            });

            // Configure the User model
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });
        }
}

