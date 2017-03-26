using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebmailServer.ViewModels
{
    public class EmailVM
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int[] Receivers { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
