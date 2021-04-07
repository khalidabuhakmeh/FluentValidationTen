using System;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationTen.Models
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlite("Data Source=database.db");
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var id = 0;
            var users = 
                new Bogus.Faker<User>()
                .Rules((faker, user) =>
                {
                    id++;
                    user.Id = id;
                    user.Username = $"{faker.Person.UserName}_{id}";
                })
                .Generate(10_000);
            
            modelBuilder
                .Entity<User>()
                .HasData(users);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}