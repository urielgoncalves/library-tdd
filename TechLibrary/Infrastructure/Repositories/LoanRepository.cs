using System;
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

        public async Task<IQueryable<LoanEntity>> Read(int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<LoanEntity> Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoanEntity> Update(LoanEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
