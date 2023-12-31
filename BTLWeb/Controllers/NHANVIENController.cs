﻿using BTLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWeb.Controllers
{
    public class NHANVIENController : Controller
    {
        private Models.QLQCFEntities db = new Models.QLQCFEntities();
        // GET: NHANVIEN
        public ActionResult Info()
        {
            QLQCFEntities db = new QLQCFEntities();
            List<NHANVIEN> nv = db.NHANVIEN.ToList();
            return View(nv);
            
        }
        [HttpGet]
        public ActionResult AddNV()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNV(NHANVIEN nv)
        {
            QLQCFEntities db = new QLQCFEntities();
            db.NHANVIEN.Add(nv);
            db.SaveChanges();
            return RedirectToAction("Info");
        }
        [HttpGet]
        public ActionResult UpdateNV(string id)
        {
            var obj = db.NHANVIEN.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult UpdateNV(NHANVIEN obj)
        {
            var edncc = db.NHANVIEN.Find(obj.MANV);
            edncc.MANV = obj.MANV;
            edncc.TENNV = obj.TENNV;
            edncc.NGAYSINH = obj.NGAYSINH;
            edncc.GIOITINH = obj.GIOITINH;
            edncc.DIACHI = obj.DIACHI;
            edncc.SDT= obj.SDT;
            edncc.LUONG = obj.LUONG;
            edncc.ANHNV = obj.ANHNV;
            db.SaveChanges();

            return RedirectToAction("Info");
        }
        [HttpGet]
        public ActionResult DeleteNV(string id)
        {
            var obj = db.NHANVIEN.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteNVConfirm(NHANVIEN obj)
        {
            var nv = db.NHANVIEN.Find(obj.MANV);
            if (nv != null)
            {
                db.NHANVIEN.Remove(nv);
                db.SaveChanges();
            }

            return RedirectToAction("Info");
        }
    }
}