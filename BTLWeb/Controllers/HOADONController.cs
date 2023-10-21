using BTLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWeb.Controllers
{
    public class HOADONController : Controller
    {
        private Models.QLQCFEntities db = new Models.QLQCFEntities();
        // GET: HOADON
        public ActionResult Info()
        {
            QLQCFEntities db = new QLQCFEntities();
            List<HOADON> hd = db.HOADON.ToList();
            return View(hd);
        }
        [HttpGet]
        public ActionResult AddHD()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHD(HOADON hd)
        {
            QLQCFEntities db = new QLQCFEntities();
            db.HOADON.Add(hd);
            db.SaveChanges();
            return RedirectToAction("Info");
        }
        [HttpGet]
        public ActionResult UpdateHD(string id)
        {
            var obj = db.HOADON.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult UpdateHD(HOADON obj)
        {
            var edncc = db.HOADON.Find(obj.MAHD);
            edncc.MAHD = obj.MAHD;
            edncc.MANV = obj.MANV;
            edncc.NGAYLAP = obj.NGAYLAP;
            edncc.THANHTIEN = obj.THANHTIEN;
            db.SaveChanges();

            return RedirectToAction("Info");
        }
    }
}