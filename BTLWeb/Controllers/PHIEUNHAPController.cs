using BTLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWeb.Controllers
{
    public class PHIEUNHAPController : Controller
    {
        private Models.QLQCFEntities db = new Models.QLQCFEntities();
        // GET: PHIEUNHAP
        public ActionResult Info()
        {
            QLQCFEntities db = new QLQCFEntities();
            List<PHIEUNHAP> pn = db.PHIEUNHAP.ToList();
            return View(pn);
            
        }
        [HttpGet]
        public ActionResult AddPN()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPN(PHIEUNHAP pn)
        {
            QLQCFEntities db = new QLQCFEntities();
            db.PHIEUNHAP.Add(pn);
            db.SaveChanges();
            return RedirectToAction("Info");
        }
        [HttpGet]
        public ActionResult UpdatePN(string id)
        {
            var obj = db.PHIEUNHAP.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult UpdatePN(PHIEUNHAP obj)
        {
            var edncc = db.PHIEUNHAP.Find(obj.MAPHIEUNHAP);
            edncc.MAPHIEUNHAP = obj.MAPHIEUNHAP;
            edncc.MANCC = obj.MANCC;
            edncc.MANV = obj.MANV;
            edncc.NGAYNHAP = obj.NGAYNHAP;
            edncc.TONGTIEN = obj.TONGTIEN;
            db.SaveChanges();

            return RedirectToAction("Info");
        }
    }
}