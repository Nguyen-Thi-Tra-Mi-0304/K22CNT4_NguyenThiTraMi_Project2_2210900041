using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using K22CNT4_TTCD1_NguyenThiTraMi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Areas.NttmAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NttmCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmAdmin/NttmCategory
        public ActionResult NttmIndex()
        {
            var items = db.Categories.ToList();
            return View(items);
        }

        // Thêm mới
        public ActionResult NttmAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NttmAdd(NttmCategory model)
        {
            if (ModelState.IsValid)
            {
                model.NttmCreatedDate = DateTime.Now; //thuộc tính này trong NttmCommonAbstract
                model.NttmModifierDate = DateTime.Now; //thuộc tính này trong NttmCommonAbstract
                model.NttmAlias = K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Filter.FilterChar(model.NttmTitle);
                db.Categories.Add(model); // Thêm vào db context
                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return RedirectToAction("NttmIndex"); // Chuyển hướng đến danh sách
            }
            return View(model); // Nếu không hợp lệ, trở lại view và hiển thị lỗi
        }

        // Sửa 
        public ActionResult NttmEdit(int id) 
        {
            var item = db.Categories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NttmEdit(NttmCategory model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Attach(model);
                model.NttmCreatedDate = DateTime.Now; //thuộc tính này trong NttmCommonAbstract
                model.NttmModifierDate = DateTime.Now; //thuộc tính này trong NttmCommonAbstract
                model.NttmAlias = K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Filter.FilterChar(model.NttmTitle);

                db.Entry(model).Property(x=>x.NttmTitle).IsModified = true;
                db.Entry(model).Property(x => x.NttmDescription).IsModified = true;
                db.Entry(model).Property(x => x.NttmAlias).IsModified = true;
                db.Entry(model).Property(x => x.Link).IsModified = true;
                db.Entry(model).Property(x => x.NttmSeoDescription).IsModified = true;
                db.Entry(model).Property(x => x.NttmSeoTitle).IsModified = true;
                db.Entry(model).Property(x => x.NttmSeoKeyWords).IsModified = true;
                db.Entry(model).Property(x => x.NttmPosition).IsModified = true;
                db.Entry(model).Property(x => x.NttmModifierDate).IsModified = true;
                db.Entry(model).Property(x => x.NttmModifierBy).IsModified = true;

                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return RedirectToAction("NttmIndex"); // Chuyển hướng đến danh sách
            }
            return View(model); // Nếu không hợp lệ, trở lại view và hiển thị lỗi
        }

        //Xóa 
        [HttpPost]
        public ActionResult NttmDelete(int id)
        {
            var item = db.Categories.Find(id);
            if(item != null)
            {
               /* var DeleteItem = db.Categories.Attach(item);*/
                db.Categories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}