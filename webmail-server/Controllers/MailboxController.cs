using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebmailServer.Models;
using WebmailServer.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

            foreach (var group in userEmails)
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

        [HttpGet("user/{userId}/folder/{category}/emails", Name = "folderEmails")]
        public FolderEmailsVM FolderEmails(int userId, int category)
        {
            List<int> userIds = new List<int>();
            
            List<UserEmail> userEmails = _context.UserEmail.Include(ue => ue.Email)
                .Where(e => e.UserId == userId && e.CategoryId == category).ToList();

            List<Email> emails = _context.Email
                .Include(e => e.UserEmail)
                .Where(e => (userEmails.Select(ue => ue.EmailId).Contains(e.Id)))
                .ToList();

            foreach (Email e in emails)
            {
                userIds.AddRange(e.UserEmail.Select(ue => ue.UserId).Distinct());
            }
            userIds = userIds.Distinct().ToList();
            List<User> users = _context.User.Where(u => userIds.Contains(u.Id)).ToList();

            return new FolderEmailsVM()
            {
                emails = Mapper.Map<List<EmailVM>>(emails),
                userEmails = Mapper.Map<List<UserEmailVM>>(userEmails),
                users = Mapper.Map<List<UserVM>>(users)
            };
        }
    }
}