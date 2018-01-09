using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Index()
        {
            return View();
        }
    }
}