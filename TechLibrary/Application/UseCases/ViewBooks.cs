using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLibrary.Application.Interfaces;
using TechLibrary.Domain.Entities;

namespace TechLibrary.Application.UseCases
{
    public class ViewBooks : IViewBooks
    {
        public async Task<BookEntity> ViewAvailableBooks(int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }
    }
}
