using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TechLibrary.Domain.Entities;
using TechLibrary.Infrastructure;

namespace TechLibrary.Tests.Helpers.Factories
{
    public class LibraryContextFactory
    {
        public static LibraryContext Create()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;


            var context = new LibraryContext(options);


            var books = new[] {
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
                } };
            context.AddRange(books);
            context.SaveChanges();
            return context;
        }
    }
}
