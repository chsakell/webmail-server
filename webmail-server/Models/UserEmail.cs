using System;
using System.Collections.Generic;

namespace WebmailServer.Models
{
    public partial class UserEmail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EmailId { get; set; }
        public int CategoryId { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsStarred { get; set; }
        public int? ParentId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Email Email { get; set; }
        public virtual UserEmail Parent { get; set; }
        public virtual ICollection<UserEmail> InverseParent { get; set; }
        public virtual User User { get; set; }
    }
}
