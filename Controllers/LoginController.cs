using Intersel_Practica.Models;
using Intersel_Practica.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Intersel_Practica.Controllers
{
    public class LoginController : Controller
    {
        LoginRepository _loginRepository = new LoginRepository();
        RoleRepository _roleRepository = new RoleRepository();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(ApplicationUser model)
        {
            try
            {
                var response = await _loginRepository.Login(model);
                if (response.Error==0)
                {
                    var roleList = await _roleRepository.GetRoles(response.User.ApplicationUserId);
                    string access = "";
                    foreach (var item in roleList)
                    {
                        access+=item.Access;
                    }
                    Session["Menu"]=access;
                    Session["User"]=response.User.UserName;
                    return Json(new { status = true, ruta = "../Home/Index" });
                }
                return Json(new { status = false, mensaje = response.DescError });
            }
            catch (Exception e)
            {
                return Json(new { mensaje = e.Message, status = false });
                throw;
            }
        }
        [HttpGet]
        public ActionResult IsLogged()
        {
            try
            {
                var usuario = System.Web.HttpContext.Current.Session["Usuario"];
                if (usuario==null)
                {
                    return Json(new { status = false }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { status = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["User"]=null;
            return RedirectToAction("Index", "Login");
        }
    }
}