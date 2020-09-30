using System;
using System.Threading.Tasks;
using TechLibrary.Application.Interfaces;
using TechLibrary.Domain.Repositories;

namespace TechLibrary.Application.UseCases
{
    public class BorrowBook : IBorrowBook
    {
        private readonly ILoanRepository _loanRepository;

        public BorrowBook(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<bool> Borrow(Guid userId, Guid bookId)
        {
            return await _loanRepository.Create(
                new Domain.Entities.LoanEntity
                {
                    BookId = bookId,
                    UserId = userId
                });
        }

        public Task<bool> UserHasAlreadyBorrowedACopyOfTheSameBook(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserHasTwoOrLessBooksBorrowed(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
