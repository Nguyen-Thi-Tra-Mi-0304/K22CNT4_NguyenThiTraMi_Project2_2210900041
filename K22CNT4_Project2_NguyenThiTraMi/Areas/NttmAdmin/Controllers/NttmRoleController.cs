using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Areas.NttmAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NttmRoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/NttmRole
        public ActionResult Index()
        {
            var items = db.Roles.ToList();
            return View(items);
        }

        // Thêm mới
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                roleManager.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Sửa 
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Trả về lỗi nếu id là null
            }

            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound(); // Xử lý trường hợp không tìm thấy vai trò
            }
            return View(role);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                // Tìm vai trò dựa trên Id của model
                var role = db.Roles.Find(model.Id);
                if (role == null)
                {
                    return HttpNotFound(); 
                }

                // Chỉ cập nhật tên của vai trò
                role.Name = model.Name;

                
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Nếu có lỗi, trả về lại View với model
            return View(model);
        }
    }
}