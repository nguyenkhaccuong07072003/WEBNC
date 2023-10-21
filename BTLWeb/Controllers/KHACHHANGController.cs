using BTLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWeb.Controllers
{
    public class KHACHHANGController : Controller
    {
        private Models.QLQCFEntities db = new Models.QLQCFEntities();
        // GET: KHACHHANG
        public ActionResult Info()
        {
            QLQCFEntities db = new QLQCFEntities();
            List<KHACHHANG> kh = db.KHACHHANG.ToList();
            return View(kh);
        }

        [HttpGet]
        public ActionResult AddKH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddKH(KHACHHANG kh)
        {
            QLQCFEntities db = new QLQCFEntities();
            db.KHACHHANG.Add(kh);
            db.SaveChanges();
            return RedirectToAction("Info");
        }
    }
}