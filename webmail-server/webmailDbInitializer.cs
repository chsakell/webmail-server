using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebmailServer.Models;

namespace WebmailServer
{
    public class webmailDbInitializer
    {
        private static webmailContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (webmailContext)serviceProvider.GetService(typeof(webmailContext));

            InitializeWebmail();
        }

        private static void InitializeWebmail()
        {
            if(!context.Category.Any())
            {
                Category inbox = new Category() { Id = 1, Name = "Inbox" };
                Category spam = new Category() { Id = 2, Name = "Spam" };
                Category draft = new Category() { Id = 3, Name = "Draft" };
                Category sent = new Category() { Id = 4, Name = "Sent" };
                Category deleted = new Category() { Id = 5, Name = "Deleted" };

                context.Category.AddRange(new Category[] { inbox, spam, draft, sent, deleted });

                context.SaveChanges();
            }

            if(!context.User.Any())
            {
                User chris = new User() { FirstName = "Christos", LastName = "Sakellarios", EmailAddress = "chsakell@webmail.com" };
                User samuel = new User() { FirstName = "Samuel", LastName = "Peers", EmailAddress = "samuel@webmail.com" };
                User giorgio = new User() { FirstName = "Giorgio", LastName = "Walerian", EmailAddress = "giorgio@webmail.com" };
                User merlin = new User() { FirstName = "Merlin", LastName = "Edmundo", EmailAddress = "merlin@webmail.com" };
                User urban = new User() { FirstName = "Urban", LastName = "Phil", EmailAddress = "urban@webmail.com" };

                context.User.AddRange(new User[] { chris, samuel, giorgio, merlin, urban });

                context.SaveChanges();
            }

            if(!context.Email.Any())
            {
                Email sentByChris = new Email()
                {
                    AuthorId = 1,
                    Subject = "Test email from Chris",
                    Body = "Email contents here",
                    UserEmail = new List<UserEmail>()
                    {
                        new UserEmail() { CategoryId = 4, UserId = 1, EmailId = 1, IsRead = true },
                        new UserEmail() { CategoryId = 1, UserId = 2, EmailId = 1 },
                        new UserEmail() { CategoryId = 5, UserId = 3, EmailId = 1, IsRead = true },
                    }
                };

                Email sentBySamuel = new Email()
                {
                    AuthorId = 2,
                    Subject = "Test email from Samuel",
                    Body = "Email contents here bla bla bla",
                    UserEmail = new List<UserEmail>()
                    {
                        new UserEmail() { CategoryId = 4, UserId = 2, EmailId = 2, IsRead = true },
                        new UserEmail() { CategoryId = 1, UserId = 1, EmailId = 2 }
                    },
                    ParentId = 1
                };

                
                Email sentByGiorgio = new Email()
                {
                    AuthorId = 3,
                    Subject = "Test email from Giorgio",
                    Body = "Email contents hello world!!1",
                    UserEmail = new List<UserEmail>()
                    {
                        new UserEmail() { CategoryId = 4, UserId = 3, EmailId = 3, IsRead = true },
                        new UserEmail() { CategoryId = 1, UserId = 1, EmailId = 3, IsRead = true },
                        new UserEmail() { CategoryId = 1, UserId = 4, EmailId = 3, IsRead = true },
                        new UserEmail() { CategoryId = 1, UserId = 5, EmailId = 3 }
                    }
                };
                

                context.Email.AddRange(new Email[] { sentByChris, sentBySamuel, sentByGiorgio });

                context.SaveChanges();
            }
        }
    }
}
