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
    public class CallController : Controller
    {
        CallRepository _callRepository = new CallRepository();
        public async Task<ActionResult> Index()
        {
            var lines=await _callRepository.GetCellLines();
            return View(lines);
        }
        [HttpPost]
        public async Task<ActionResult> GetCallDetailByMobileLine(CellLine model)
        {
            var lines = await _callRepository.GetCallDetailByMobileLine(model);
            return Json(new { status = true, lines=lines });
        }
    }
}