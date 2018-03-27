using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SercicesMS.Models;

namespace SercicesMS.Controllers
{
    public class ServicesController : Controller
    {
        private ServiceDBContext db = new ServiceDBContext();
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inf()
        {
            return View(db.Services.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,S_Name,S_Path,Pic_Path,S_User,S_Pwd,S_CreatTime")] Service service )
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Inf");
            }
            return View(service);
        }
        public ActionResult Details(int id)
        {
            Service service = db.Services.Find(id);
            return View(service);
        }
    }
}