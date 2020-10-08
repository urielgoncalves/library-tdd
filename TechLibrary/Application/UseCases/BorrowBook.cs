using System;
using System.Linq;
using System.Threading.Tasks;
using TechLibrary.Application.Interfaces;
using TechLibrary.Domain.Repositories;

namespace TechLibrary.Application.UseCases
{
    public class BorrowBook : IBorrowBook
    {
        private const int BOOK_LIMIT_PER_USER = 2;
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public BorrowBook(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }
        public async Task<bool> Borrow(Guid userId, Guid bookId)
        {
            if (!await UserHasLessThanTwoBooksBorrowed(userId))
                return false;

            if (await UserHasAlreadyBorrowedACopyOfTheSameBook(userId, bookId))
                return false;

            return await _loanRepository.Create(
                new Domain.Entities.LoanEntity
                {
                    BookId = bookId,
                    UserId = userId
                });
        }

        public async Task<bool> UserHasAlreadyBorrowedACopyOfTheSameBook(Guid userId, Guid bookToBorrowId)
        {
            var loans = await _loanRepository.ReadByUserId(userId);
            var borrowedIsbn = _bookRepository.ReadAll()
                .Where(book => loans.Select(loan => loan.BookId)
                .Contains(book.Id))
                .Select(book=>book.ISBN);

            var bookToBorrow = await _bookRepository.Read(bookToBorrowId);

            return borrowedIsbn.Contains(bookToBorrow.ISBN);
        }

        public async Task<bool> UserHasLessThanTwoBooksBorrowed(Guid userId)
        {
            var activeLoans = await _loanRepository.ReadActiveLoans();
            return activeLoans.Count() < BOOK_LIMIT_PER_USER;
        }
    }
}
