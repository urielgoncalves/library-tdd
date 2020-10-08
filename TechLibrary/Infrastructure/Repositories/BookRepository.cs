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
        private readonly LibraryContext _libraryContext;
        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<bool> Create(BookEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<BookEntity> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookEntity>> Read(int skip = 0, int take = 10)
        {
            return _libraryContext.Books.Skip(skip).Take(take);
        }

        public async Task<BookEntity> Read(Guid id)
        {
            return _libraryContext.Books.FirstOrDefault(book => book.Id == id);
        }

        public IQueryable<BookEntity> ReadAll()
        {
            return _libraryContext.Books;
        }

        public async Task<BookEntity> Update(BookEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
