using Microsoft.AspNetCore.Mvc;
using TecnoFood.Commands.User;
using TecnoFood.Data;
using TecnoFood.Models;
using TecnoFood.Services;

namespace TecnoFood.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AuthenticateAsync([FromBody] LoginUserCommand login)
        {
            //Recuperar o usuario

            var user = _context.Users.FirstOrDefault(User => User.Email.Equals(login.Email) && User.Password.Equals(login.Password));

            if (user == null)
                return NotFound(new { message = "Usuario ou senha invalidos" });

            var token = TokenService.GerenateToken(user);
            user.Password = "";

            return Ok(new
            {
                User = user,
                Token = token
            });
        }
    }
}
