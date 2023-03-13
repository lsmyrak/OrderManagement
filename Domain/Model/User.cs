using Domain.Common;
using System;

namespace Domain.Model
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; } = 1;
        public virtual Role UserRole { get; set; }

    }
}
