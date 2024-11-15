using HotelierProject.EntityLayer.Concrete;
using HotelierProject.WebUI.Dtos.RoleDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelierProject.WebUI.Controllers
{
    public class RoleController:Controller
    {

        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult RoleList()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AppRole appRole)
        {
            AppRole role = new AppRole()
            {
                Name = appRole.Name,
                NormalizedName = appRole.NormalizedName,
                ConcurrencyStamp = appRole.ConcurrencyStamp,
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value =await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(value!);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleDto updateRoleDto = new UpdateRoleDto()
            {
                Id = value!.Id,
                Name = value.Name,
            };

            return View(updateRoleDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleDto.Id);
            value!.Name = updateRoleDto.Name;
            await _roleManager.UpdateAsync(value);

            return RedirectToAction("RoleList");
        }

    }
}
