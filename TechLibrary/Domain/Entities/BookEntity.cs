using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechLibrary.Domain.Entities
{
    public class BookEntity : EntityBase
    {
        public string Title { get; set; }
        public string ISBN { get; set; }

        public ICollection<LoanEntity> Loans { get; set; }
    }
}
