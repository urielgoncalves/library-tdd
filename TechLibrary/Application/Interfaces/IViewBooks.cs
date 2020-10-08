using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLibrary.Domain.Entities;

namespace TechLibrary.Application.Interfaces
{
    public interface IViewBooks
    {

        Task<BookEntity> ViewAvailableBooks(int skip = 0, int take = 10);
    }
}
