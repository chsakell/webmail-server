using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebmailServer.ViewModels
{
    public class FolderEmailsVM
    {
        public FolderEmailsVM()
        {
            emails = new List<EmailVM>();
            userEmails = new List<UserEmailVM>();
            users = new List<UserVM>();
        }
        public ICollection<EmailVM> emails { get; set; }
        public ICollection<UserEmailVM> userEmails { get; set; }
        public ICollection<UserVM> users { get; set; }
    }
}
