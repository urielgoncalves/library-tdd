using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechLibrary.Common;
using TechLibrary.Domain.Entities;

namespace TechLibrary.Infrastructure
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LoanEntity> Loan { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        break;
                    case EntityState.Modified:
                        
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<BookEntity>().ToTable("Book")
                .HasIndex(entity => new { entity.Id, entity.ISBN });
            builder.Entity<BookEntity>().HasKey(book => book.Id);

            builder.Entity<BookEntity>().HasData(
                new BookEntity
                { 
                    ISBN = "9781449331818",
                    Title = "Learning JavaScript Design Patterns"
                },
                 new BookEntity
                 {
                     ISBN = "9781449331818",
                     Title = "Learning JavaScript Design Patterns"
                 },
                new BookEntity
                {
                    ISBN = "9781491950296",
                    Title = "Programming JavaScript Applications"
                });



            builder.Entity<UserEntity>().ToTable("User")
                .HasIndex(entity => new { entity.Id, entity.Email });

            builder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Email = "test@test.com",
                    Name = "User 1",
                    Active = true
                });

            builder.Entity<UserEntity>().HasKey(user => user.Id);

            builder.Entity<LoanEntity>().HasKey(loan => loan.Id);
        }
    }
}
