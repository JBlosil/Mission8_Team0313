using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission8_Team0313.Models
{
    public class TimeManagementContext : DbContext
    {
        public TimeManagementContext(DbContextOptions<TimeManagementContext> options) : base(options)
        {

        }
        public DbSet<Action> Actions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Time_Management.sqlite");
        }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
/*            modelBuilder.Entity<Action>(entity =>
            {
                entity.HasKey(e => e.TaskID);

                entity.Property(e => e.TaskID).HasColumnName("TaskID");
                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName, "IX_Categories_Category").IsUnique();

                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");
                entity.Property(e => e.CategoryName).HasColumnName("Category");
            });*/

            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
            );

        }

    }
}
