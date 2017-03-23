using System;
using System.Collections.Generic;

namespace WebmailServer.Models
{
    public partial class Category
    {
        public Category()
        {
            UserEmail = new HashSet<UserEmail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserEmail> UserEmail { get; set; }
    }
}
