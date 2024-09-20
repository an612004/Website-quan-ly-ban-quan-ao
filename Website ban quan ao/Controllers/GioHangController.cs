using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_ban_quan_ao.Models;

namespace Website_ban_quan_ao.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ApplicationDbcontext db = new ApplicationDbcontext();

        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
    }
}