using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebmailServer.ViewModels
{
    public class EmailHistoryVM
    {
        public EmailHistoryVM()
        {
            emails = new List<EmailVM>();
            users = new List<UserVM>();
        }
        public ICollection<EmailVM> emails { get; set; }
        public ICollection<UserVM> users { get; set; }
    }
}
