using BTLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWeb.Controllers
{
    public class DONHANGController : Controller
    {
        private Models.QLQCFEntities db = new Models.QLQCFEntities();
        // GET: DONHANG
        public ActionResult Info()
        {
            QLQCFEntities db = new QLQCFEntities();
            List<DONHANG> dh = db.DONHANG.ToList();
            return View(dh);
            
        }
        [HttpGet]
        public ActionResult AddDH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDH(DONHANG dh)
        {
            QLQCFEntities db = new QLQCFEntities();
            db.DONHANG.Add(dh);
            db.SaveChanges();
            return RedirectToAction("Info");
        }

        [HttpGet]
        public ActionResult UpdateDH(string id)
        {
            var obj = db.DONHANG.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult UpdateDH(DONHANG obj)
        {
            var edncc = db.DONHANG.Find(obj.MADH);
            edncc.MADH = obj.MADH;
            edncc.ID = obj.ID;
            edncc.NGAYDAT = obj.NGAYDAT;
            edncc.TONGTIENTT = obj.TONGTIENTT;
            db.SaveChanges();

            return RedirectToAction("Info");
        }
        
            }
        }
