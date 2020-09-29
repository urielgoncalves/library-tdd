using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechLibrary.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public ICollection<LoanEntity> Loans { get; set; }
    }
}
