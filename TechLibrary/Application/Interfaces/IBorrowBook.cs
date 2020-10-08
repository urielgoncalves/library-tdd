using System;
using System.Threading.Tasks;

namespace TechLibrary.Application.Interfaces
{
    public interface IBorrowBook
    {
        Task<bool> Borrow(Guid userId, Guid bookId);
        Task<bool> UserHasLessThanTwoBooksBorrowed(Guid userId);
        Task<bool> UserHasAlreadyBorrowedACopyOfTheSameBook(Guid userId, Guid bookToBorrowId);
    }
}
