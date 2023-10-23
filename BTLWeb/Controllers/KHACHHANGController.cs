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

        [HttpGet]
        public ActionResult UpdateKH(string id)
        {
            var obj = db.KHACHHANG.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult UpdateKH(KHACHHANG obj)
        {
            var edncc = db.KHACHHANG.Find(obj.ID);
            edncc.ID= obj.ID;
            edncc.TENKH = obj.TENKH;
            edncc.DIACHI = obj.DIACHI;
            edncc.SDT = obj.SDT;
            edncc.ANHKH = obj.ANHKH;
            db.SaveChanges();

            return RedirectToAction("Info");
        }
        [HttpGet]
        public ActionResult DeleteKH(string id)
        {
            var obj = db.KHACHHANG.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteKHConfirm(KHACHHANG obj)
        {
            var kh = db.KHACHHANG.Find(obj.ID);
            if (kh != null)
            {
                db.KHACHHANG.Remove(kh);
                db.SaveChanges();
            }

            return RedirectToAction("Info");
        }
    }
}