using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebmailServer.Models;

namespace webmail_server.Controllers
{
    [Produces("application/json")]
    [Route("api/Emails")]
    public class EmailsController : Controller
    {
        private readonly webmailContext _context;

        public EmailsController(webmailContext context)
        {
            _context = context;
        }

        [HttpGet("init/{id}", Name = "Init")]
        public IEnumerable<Email> Init(int id)
        {
            return _context.Email;
        }

        // GET: api/Emails
        [HttpGet]
        public IEnumerable<Email> GetEmail()
        {
            return _context.Email;
        }

        // GET: api/Emails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email = await _context.Email.SingleOrDefaultAsync(m => m.Id == id);

            if (email == null)
            {
                return NotFound();
            }

            return Ok(email);
        }

        // PUT: api/Emails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail([FromRoute] int id, [FromBody] Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != email.Id)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Emails
        [HttpPost]
        public async Task<IActionResult> PostEmail([FromBody] Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Email.Add(email);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmail", new { id = email.Id }, email);
        }

        // DELETE: api/Emails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email = await _context.Email.SingleOrDefaultAsync(m => m.Id == id);
            if (email == null)
            {
                return NotFound();
            }

            _context.Email.Remove(email);
            await _context.SaveChangesAsync();

            return Ok(email);
        }

        private bool EmailExists(int id)
        {
            return _context.Email.Any(e => e.Id == id);
        }
    }
}