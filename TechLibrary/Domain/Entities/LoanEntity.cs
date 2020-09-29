using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechLibrary.Domain.Entities
{
    public class LoanEntity : EntityBase
    {
        public UserEntity User { get; set; }
        public BookEntity Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
