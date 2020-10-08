using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechLibrary.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<bool> Create(T entity);

        Task<IEnumerable<T>> Read(int skip = 0, int take = 10);
        IQueryable<T> ReadAll();

        Task<T> Read(Guid id);

        Task<T> Update(T entity);

        Task<T> Delete(Guid id);
    }
}
