using BTLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWeb.Controllers
{
    public class NHACUNGCAPController : Controller
    {
        private Models.QLQCFEntities db = new Models.QLQCFEntities();
        // GET: NHACUNGCAP
        public ActionResult Info()
        {
            QLQCFEntities db = new QLQCFEntities();
            List<NHACUNGCAP> ncc = db.NHACUNGCAP.ToList();
            return View(ncc);
        }
        [HttpGet]
        public ActionResult AddNCC()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNCC (NHACUNGCAP ncc)
        {
            QLQCFEntities db = new QLQCFEntities();
            db.NHACUNGCAP.Add(ncc);
            db.SaveChanges();
            return RedirectToAction("Info");
        }

        [HttpGet]
        public ActionResult UpdateNCC(string id)
        {
            var obj = db.NHACUNGCAP.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult UpdateNCC(NHACUNGCAP obj)
        {
            var edncc = db.NHACUNGCAP.Find(obj.MANCC);
            edncc.MANCC = obj.MANCC;
            edncc.TENNCC = obj.TENNCC;
            edncc.DIACHI = obj.DIACHI;
            edncc.SDT = obj.SDT;
            db.SaveChanges();

            return RedirectToAction("Info");
        }
        [HttpGet]
        public ActionResult DeleteNCC(string mancc)
        {
            var obj = db.NHACUNGCAP.Find(mancc);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteNCCConfirm(NHACUNGCAP obj)
        {
            var delncc = db.NHACUNGCAP.Find(obj.MANCC);
            if (delncc!=null)
            {
                db.NHACUNGCAP.Remove(delncc);
                db.SaveChanges();
            }


            return RedirectToAction("Info");
        }
        
    }
}