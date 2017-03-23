using System;
using System.Collections.Generic;

namespace WebmailServer.Models
{
    public partial class User
    {
        public User()
        {
            Email = new HashSet<Email>();
            UserEmail = new HashSet<UserEmail>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Email> Email { get; set; }
        public virtual ICollection<UserEmail> UserEmail { get; set; }
    }
}
