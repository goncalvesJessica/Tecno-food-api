using Microsoft.AspNetCore.Mvc;
using TecnoFood.Data;
using TecnoFood.Commands.User;
using TecnoFood.Models;
using Microsoft.AspNetCore.Authorization;

namespace TecnoFood.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaUser([FromBody] CreateUserCommand command)
        {
            User user = new(command);
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(AdicionaUser),
                new { id = user.Id },
                user);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<User> RecuperarUsers()
        {
            return _context.Users;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarUserPorId(int id)
        {
            var User = _context.Users.FirstOrDefault(User => User.Id == id);

            if (User == null) return NotFound();

            return Ok(User);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUser(int id, [FromBody] UpdateUserCommand command)
        {
            var user = _context.Users.FirstOrDefault(User => User.Id == id);
            if (user == null) return NotFound();

            user.Update(command);
            _context.Users.Update(user);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var User = _context.Users.FirstOrDefault(User => User.Id == id);
            if (User == null) return NotFound();

            _context.Remove(User);
            _context.SaveChanges();
            return Ok();
        }
    }
}
