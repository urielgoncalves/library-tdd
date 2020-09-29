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
        public Task<BookEntity> Create(BookEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<BookEntity> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<BookEntity>> Read(int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public Task<BookEntity> Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BookEntity> Update(BookEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
