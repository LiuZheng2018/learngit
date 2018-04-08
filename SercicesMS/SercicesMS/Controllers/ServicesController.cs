using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SercicesMS.Models;
using System.Data.Entity;
using System.IO;

namespace SercicesMS.Controllers
{
    public class ServicesController : Controller
    {
        private ServiceDBContext db = new ServiceDBContext();
        // GET: Services
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }
        public ActionResult Inf(string userName,string serviceName)
        {
            //获取用户列表，去重
            var UserLit = new List<string>();
            var UserQry = from d in db.Services
                           orderby d.S_User
                           select d.S_User;
            UserLit.AddRange(UserQry.Distinct());
            ViewBag.userName = new SelectList(UserLit);
            //默认
            var services = from s in db.Services
                           select s;
            //筛选1：按服务名筛选
            if (!String.IsNullOrEmpty(serviceName))
            {
                services = services.Where(s => s.S_Name.Contains(serviceName));
            }
            //筛选2：按用户名筛选
            if (!String.IsNullOrEmpty(userName))
            {
                services = services.Where(s => s.S_User == userName);
            }

            return View(services);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,S_Name,S_Path,Pic_Path,S_User,S_Pwd,S_CreatTime,S_LastTime,S_Admin,S_Remark")] Service service, HttpPostedFileBase Pic)
        {
            //上传图片
            if (Pic!=null)
            {
                var fileName = Pic.FileName;
                var filePath = Server.MapPath(string.Format("~/{0}", "File"));
                service.Pic_Path = "/File/" + fileName;
                Pic.SaveAs(Path.Combine(filePath, fileName));
            }
            //获取创建和修改时间
            service.S_CreatTime = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            service.S_LastTime = service.S_CreatTime;
            //
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
        public ActionResult Edit(int id)
        {
            Service service = db.Services.Find(id);
            return View(service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,S_Name,S_Path,Pic_Path,S_User,S_Pwd,S_CreatTime,S_LastTime,S_Admin,S_Remark")] Service service, HttpPostedFileBase Pic)
        {
            //更改图片
            if (Pic != null)
            {
                var fileName = Pic.FileName;
                var filePath = Server.MapPath(string.Format("~/{0}", "File"));
                service.Pic_Path = "/File/" + fileName;
                Pic.SaveAs(Path.Combine(filePath, fileName));
            }
            //修改时间
            service.S_LastTime = DateTime.Now.ToLongDateString()+" "+DateTime.Now.ToLongTimeString();
            //
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Inf");
            }
            return View(service);

        }
        public ActionResult Delete(int id)
        {
            Service service = db.Services.Find(id);
            return View(service);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Inf");
        }
      
     
    }
}