using BTLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWeb.Controllers
{
    public class SANPHAMController : Controller
    {
        private Models.QLQCFEntities db = new Models.QLQCFEntities();
        // GET: SANPHAM
        public ActionResult Info()
        {
            QLQCFEntities db = new QLQCFEntities();
            List<SANPHAM> sp = db.SANPHAM.ToList();
            return View(sp);
            
        }
        [HttpGet]
        public ActionResult AddSP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSP(SANPHAM sp)
        {
            QLQCFEntities db = new QLQCFEntities();
            db.SANPHAM.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Info");
        }
        [HttpGet]
        public ActionResult UpdateSP(string id)
        {
            var obj = db.SANPHAM.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult UpdateSP(SANPHAM obj)
        {
            var edncc = db.SANPHAM.Find(obj.MASP);
            edncc.MASP = obj.MASP;
            edncc.TENSP= obj.TENSP;
            edncc.MOTA = obj.MOTA;
            edncc.DONGIA = obj.DONGIA;
            edncc.ANHSP = obj.ANHSP;
            db.SaveChanges();

            return RedirectToAction("Info");
        }
    }
}