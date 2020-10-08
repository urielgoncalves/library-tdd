using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechLibrary.REST.Payloads
{
    public class BorrowBookPayload
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
