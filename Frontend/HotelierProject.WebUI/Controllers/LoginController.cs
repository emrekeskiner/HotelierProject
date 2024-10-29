using HotelierProject.EntityLayer.Concrete;
using HotelierProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
           if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password,false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("StaffList", "Staff");
                }else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
