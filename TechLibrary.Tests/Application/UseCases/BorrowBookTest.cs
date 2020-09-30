using System;
using TechLibrary.Application.UseCases;
using TechLibrary.Domain.Repositories;
using TechLibrary.Infrastructure;
using TechLibrary.Infrastructure.Repositories;
using TechLibrary.Tests.Helpers.Factories;
using Xunit;

namespace TechLibrary.Tests.Application.UseCases
{
    public class BorrowBookTest
    {
        private LibraryContext _libraryContext;
        private readonly ILoanRepository _loanRepository;

        public BorrowBookTest()
        {
            _libraryContext = LibraryContextFactory.Create();
            _loanRepository = new LoanRepository(_libraryContext);
        }

        [Fact]
        public async void ItShouldValidateMaxTwoBooksPerUser()
        {

        }

        [Fact]
        public async void ItShouldValidateOneCopyOfABookPerUser()
        {

        }

        [Fact]
        public async void ItShouldInsertBookToMyBorrowedList()
        {
            Guid userId = Guid.NewGuid();
            Guid bookId = Guid.NewGuid();
            var borrowBook = new BorrowBook(_loanRepository);

            var result = await borrowBook.Borrow(userId, bookId);

            Assert.True(result);
        }

        [Fact]
        public async void ItShouldValidateIfBookHasBeenRemovedFromTheLibrary()
        {

        }
    }
}
