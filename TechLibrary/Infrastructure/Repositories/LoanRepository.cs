using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories;

namespace TechLibrary.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryContext _libraryContext;
        public LoanRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public async Task<bool> Create(LoanEntity entity)
        {
            _libraryContext.Loan.Add(entity);
            return await _libraryContext.SaveChangesAsync() > 0;
        }

        public async Task<LoanEntity> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LoanEntity>> Read(int skip = 0, int take = 10)
        {
            return _libraryContext.Loan.Skip(skip).Take(take);
        }

        public async Task<LoanEntity> Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LoanEntity>> ReadByUserId(Guid userId)
        {
            return await Task.FromResult(_libraryContext.Loan.Where(loan => loan.UserId == userId));
        }

        public IQueryable<LoanEntity> ReadAll()
        {
            return _libraryContext.Loan;
        }

        public async Task<IEnumerable<LoanEntity>> ReadActiveLoans()
        {
            return await Task.FromResult(_libraryContext.Loan.Where(loan => loan.ReturnDate == null 
            || loan.ReturnDate == DateTime.MinValue));
        }

        public async Task<LoanEntity> Update(LoanEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
