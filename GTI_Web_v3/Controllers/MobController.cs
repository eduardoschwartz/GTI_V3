using GTI_Web_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GTI_Web_v3.Controllers
{
    public class MobController : Controller
    {
        // GET: Mob
        
        [HttpGet]
        public ActionResult MobDetail()
        {
            return View();
        }

        [HttpPost]
        public string MobDetail(DadosEmpresaViewModel model) {
            if (ModelState.IsValid) {



            }
            return model.Codigo.ToString();
        }

    }
}