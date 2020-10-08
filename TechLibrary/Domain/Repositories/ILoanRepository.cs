using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechLibrary.Domain.Entities;

namespace TechLibrary.Domain.Repositories
{
    public interface ILoanRepository : IRepository<LoanEntity>
    {
        Task<IEnumerable<LoanEntity>> ReadByUserId(Guid userId);
        Task<IEnumerable<LoanEntity>> ReadActiveLoans();
    }
}
