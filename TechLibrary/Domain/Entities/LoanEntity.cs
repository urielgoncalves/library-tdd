using System;

namespace TechLibrary.Domain.Entities
{
    public class LoanEntity : EntityBase
    {
        public Guid UserId { get; set; } 
        public UserEntity User { get; set; }
        public Guid BookId { get; set; }
        public BookEntity Book { get; set; }
        public DateTime BorrowDate => DateTime.Now;
        public DateTime ReturnDate { get; set; }
    }
}
