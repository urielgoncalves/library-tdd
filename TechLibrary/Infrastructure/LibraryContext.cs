using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

       // protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=library.db");

        protected override void OnModelCreating(ModelBuilder builder) {
            //builder.ApplyConfigurationsFromAssembly(typeof(LibraryContext).Assembly);

            //builder.Entity<BookEntity>().ToTable("Book")
            //    .HasIndex(entity => new { entity.Id, entity.ISBN });
            //builder.Entity<BookEntity>().HasKey(book => book.Id);

            //builder.Entity<UserEntity>().ToTable("User")
            //    .HasIndex(entity => new { entity.Id, entity.Email });
            //builder.Entity<UserEntity>().HasKey(user => user.Id);

            //builder.Entity<LoanEntity>().ToTable("Loan")
            //    .HasIndex(entity => new { entity.User, entity.Book });
        }
    }
}
