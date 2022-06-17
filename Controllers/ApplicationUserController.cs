using Intersel_Practica.Dto;
using Intersel_Practica.Repositories;
using Intersel_Practica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Intersel_Practica.Controllers
{
    public class ApplicationUserController : Controller
    {
        UserRepository _userRepository = new UserRepository();
        RoleRepository _roleRepository = new RoleRepository();
        // GET: ApplicationUser
        public async Task<ActionResult> Index()
        {
            try
            {

                var viewModel = new UserViewModel();
                viewModel.Users=await _userRepository.GetUsers();
                viewModel.Roles=await _roleRepository.GetRoles(0);
                return View(viewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult> CRUDUser(UserDto dto)
        {
            try
            {
                var result = await _userRepository.CRUDUser(dto);
                if (result.Error==0)
                {
                    return Json(new { status = true});
                }
                else
                {
                    return Json(new { status = false, message = result.DescError });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Json(new { status = false, message = e.Message });
                throw;
            }
        }
    }
}