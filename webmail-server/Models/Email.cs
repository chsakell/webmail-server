using System;
using System.Collections.Generic;

namespace WebmailServer.Models
{
    public partial class Email
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime? DateCreated { get; set; }
        public int AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
