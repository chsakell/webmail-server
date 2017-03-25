using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebmailServer.Models;
using WebmailServer.ViewModels;

namespace webmail_server.Controllers
{
    [Produces("application/json")]
    [Route("api/Mailbox")]
    public class MailboxController : Controller
    {
        private readonly webmailContext _context;

        public MailboxController(webmailContext context)
        {
            _context = context;
        }

        [HttpGet("user/{userId}/folders", Name = "folders")]
        public IEnumerable<MailboxFolder> Folders(int userId)
        {
            List<MailboxFolder> mailboxFolders = new List<MailboxFolder>();

            var userEmails = _context.UserEmail
                .Where(e => e.UserId == userId)
                .GroupBy(e => e.CategoryId)
                .ToList();

            foreach(var group in userEmails)
            {
                MailboxFolder folder = new MailboxFolder()
                {
                     Category = group.Key,
                     TotalEmails = group.Count(),
                     UnreadEmails = group.Where(e => e.IsRead == false).Count()
                };

                mailboxFolders.Add(folder);
            }


            return mailboxFolders;
        }
    }
}