using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Streaming.WebApp.Data;
using Streaming.WebApp.Models;
using Streaming.WebApp.Services;

namespace Streaming.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly StreamingWebAppContext _context;
        private readonly IConfiguration _configuration;
        public UsersController(StreamingWebAppContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Users
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users/register
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{register}")]
        public async Task<ActionResult<User>> RegisterPostUser(UserRegisterInfo user)
        {
            var password = BCrypt.Net.BCrypt.HashPassword(user.Password, _configuration["salt"]);
            var tUser = new User { Email = user.Email, Username = user.Username, Token = password };
            _context.User.Add(tUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = tUser.UserId }, "User Created");
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{login}")]
        public async Task<ActionResult<User>> LoginPostUser(UserLoginInfo user)
        {
            var tUser = _context.User
                .Where(x => x.Email == user.UsernameEmail || x.Username == user.UsernameEmail)
                .Where(x => x.Token 
                == 
                BCrypt.Net.BCrypt.HashPassword(user.Password, _configuration["salt"])).FirstOrDefault();

            if (tUser == null)
                return NotFound(tUser);

            var Jwt = new JwtService(_configuration);
            var token = Jwt.GenerateSecurityToken(tUser.Email);
            return CreatedAtAction("Login", new { Token = token}, "new token");
        }

        // DELETE: api/Users/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
