using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebmailServer.ViewModels
{
    public class MailboxFolder
    {
        public int Category { get; set; }
        public int TotalEmails { get; set; }
        public int UnreadEmails { get; set; }
    }
}
