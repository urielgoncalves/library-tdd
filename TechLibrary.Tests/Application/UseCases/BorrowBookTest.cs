using System;
using System.Linq;
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
        private readonly IBookRepository _bookRepository;

        public BorrowBookTest()
        {
            _libraryContext = LibraryContextFactory.Create();
            _loanRepository = new LoanRepository(_libraryContext);
            _bookRepository = new BookRepository(_libraryContext);
        }

        [Fact]
        public async void ItShouldValidateMaxTwoBooksPerUser()
        {
            var borrowBook = new BorrowBook(_loanRepository, _bookRepository);
            var books = _bookRepository.ReadAll().ToList();
            Guid userId = Guid.NewGuid();
            Guid bookId = books.ElementAt(0).Id;
            Guid bookId2 = books.ElementAt(1).Id;
            Guid bookId3 = books.ElementAt(2).Id;

            var borrowed1 = borrowBook.Borrow(userId, bookId).Result;
            var borrowed2 = borrowBook.Borrow(userId, bookId2).Result;
            var borrowed3 = borrowBook.Borrow(userId, bookId3).Result;


            Assert.True(borrowed1);
            Assert.False(borrowed2);
            Assert.True(borrowed3);
        }


        [Fact]
        public async void ItShouldReturnTrueIfUserHasLessThanTwoBooksBorrowed()
        {
            var borrowBook = new BorrowBook(_loanRepository, _bookRepository);
            var books = _bookRepository.ReadAll().ToList();
            Guid userId = Guid.NewGuid();
            Guid bookId = books.ElementAt(0).Id;

            var borrowed = await borrowBook.Borrow(userId, bookId);
            var valid = await borrowBook.UserHasLessThanTwoBooksBorrowed(userId);

            Assert.True(valid);
        }

        [Fact]
        public async void ItShouldReturnFalseIfUserHasLessThanTwoBooksBorrowed()
        {
            var borrowBook = new BorrowBook(_loanRepository, _bookRepository);

            var books = _bookRepository.ReadAll().ToList();
            Guid userId = Guid.NewGuid();
            Guid bookId = books.ElementAt(0).Id;
            Guid bookId2 = books.ElementAt(2).Id;

            var borrowed1 = await borrowBook.Borrow(userId, bookId);
            var borrowed2 = await borrowBook.Borrow(userId, bookId2);

            var valid = await borrowBook.UserHasLessThanTwoBooksBorrowed(userId);

            Assert.False(valid);
        }

        [Fact]
        public async void ItShouldValidateIfUserHasBorrowedACopyOfTheSameBook()
        {
            var borrowBook = new BorrowBook(_loanRepository, _bookRepository);
            string isbn = "9781449331818";
            var books = _bookRepository.ReadAll().ToList();
            Guid userId = Guid.NewGuid();

            var borrowed1 = await borrowBook.Borrow(userId, books.ElementAt(0).Id);
            //var borrowed2 = await borrowBook.Borrow(userId, books.ElementAt(1).Id);

            var firstValidation = await borrowBook.UserHasAlreadyBorrowedACopyOfTheSameBook(userId, books.ElementAt(1).Id);

            Assert.True(firstValidation);



            var secondValidation = await borrowBook.UserHasAlreadyBorrowedACopyOfTheSameBook(userId, books.ElementAt(2).Id);

            Assert.False(secondValidation);
        }

        [Fact]
        public async void ItShouldInsertBookToMyBorrowedList()
        {
            var books = _bookRepository.ReadAll().ToList();
            Guid userId = Guid.NewGuid();
            Guid bookId = books.ElementAt(0).Id;
            var borrowBook = new BorrowBook(_loanRepository, _bookRepository);

            var result = await borrowBook.Borrow(userId, bookId);

            Assert.True(result);
        }

        [Fact]
        public async void ItShouldValidateIfBookHasBeenRemovedFromTheLibrary()
        {

        }
    }
}
