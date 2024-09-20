using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_ban_quan_ao.Models;

namespace Website_ban_quan_ao.Areas.Admin.Controllers
{
    public class KieudangsController : Controller

    {
        private ApplicationDbcontext db = new ApplicationDbcontext();
        // GET: Admin/Kieudangs
        public ActionResult Index()
        {
            return View();
        }
    }
}