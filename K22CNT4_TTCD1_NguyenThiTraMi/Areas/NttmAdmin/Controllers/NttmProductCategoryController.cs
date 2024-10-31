using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using K22CNT4_TTCD1_NguyenThiTraMi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Areas.NttmAdmin.Controllers
{
    public class NttmProductCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmAdmin/NttmProductCategory
        public ActionResult NttmIndex()
        {
            var items = db.ProductCategories;
            return View(items);
        }

        // Thêm mới
        public ActionResult NttmAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NttmAdd(NttmProductCategory model)
        {
            if(ModelState.IsValid)
            {
                model.NttmCreatedDate = DateTime.Now;
                model.NttmModifierDate = DateTime.Now;
                model.Alias = K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Filter.FilterChar(model.NttmTitle);
                db.ProductCategories.Add(model);
                db.SaveChanges();
                return RedirectToAction("NttmIndex");
            }
            return View();
        }

        public ActionResult NttmEdit(int id)
        {
            var item = db.ProductCategories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NttmEdit(NttmProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.NttmCreatedDate = DateTime.Now;
                model.NttmModifierDate = DateTime.Now;
                model.Alias = K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Filter.FilterChar(model.NttmTitle);

                db.ProductCategories.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NttmIndex");
            }
            return View(model);
        }

        //Xóa 
        [HttpPost]
        public JsonResult NttmDelete(int id)
        {
            var newsItem = db.ProductCategories.Find(id);
            if (newsItem != null)
            {
                db.ProductCategories.Remove(newsItem);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


        // Xóa tất cả 
        public ActionResult DeleteAll(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.ProductCategories.Find(Convert.ToInt32(item));
                        db.ProductCategories.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}