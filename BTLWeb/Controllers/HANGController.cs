using BTLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWeb.Controllers
{
    public class HANGController : Controller
    {
        private Models.QLQCFEntities db = new Models.QLQCFEntities();
        // GET: HANG
        public ActionResult Info()
        {
            QLQCFEntities db = new QLQCFEntities();
            List<HANG> h = db.HANG.ToList();
            return View(h);
            
        }
        [HttpGet]
        public ActionResult AddH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddH(HANG h)
        {
            QLQCFEntities db = new QLQCFEntities();
            db.HANG.Add(h);
            db.SaveChanges();
            return RedirectToAction("Info");
        }
        [HttpGet]
        public ActionResult UpdateH(string id)
        {
            var obj = db.HANG.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult UpdateH(HANG obj)
        {
            var edncc = db.HANG.Find(obj.MAHANG);
            edncc.MAHANG = obj.MAHANG;
            edncc.TENHANG = obj.TENHANG;
            edncc.SOLUONG = obj.SOLUONG;
            edncc.HSD = obj.HSD;
            edncc.DONVITINH = obj.DONVITINH;
            edncc.DONGIA = obj.DONGIA;
            db.SaveChanges();

            return RedirectToAction("Info");
        }
    }
}