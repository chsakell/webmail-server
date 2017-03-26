using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebmailServer.ViewModels
{
    public class UserEmailVM
    {
        public int Id { get; set; }
        public int EmailId { get; set; }
        public int CategoryId { get; set; }
        public bool IsRead { get; set; }
        public bool IsStarred { get; set; }
        public int? ParentId { get; set; }
    }
}
