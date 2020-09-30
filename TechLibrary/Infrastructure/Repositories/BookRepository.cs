using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories;

namespace TechLibrary.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        public async Task<bool> Create(BookEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<BookEntity> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<BookEntity>> Read(int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<BookEntity> Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookEntity> Update(BookEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
