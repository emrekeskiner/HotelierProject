using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult TokenOlustur()
        {
            return Ok(new CreateToken().TokenCreate());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test2()
        {
            return Ok("Hoşgeldiniz");
        }

        [HttpGet("[action]")]
        public IActionResult AdminTokenOlustur()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }


        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3()
        {
            return Ok("Token başarılı şekilde giriş yaptı.");
        }
    }
}
