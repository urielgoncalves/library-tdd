using Microsoft.EntityFrameworkCore;
using System;
using TechLibrary.Infrastructure;

namespace TechLibrary.Tests.Helpers.Factories
{
    public class LibraryContextFactory
    {
        public static LibraryContext Create()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            return new LibraryContext(options);
        }
    }
}
