using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using K22CNT4_TTCD1_NguyenThiTraMi.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Areas.NttmAdmin.Controllers
{
    public class NttmNewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmAdmin/NttmNew
        public ActionResult NttmIndex(string searchText, int? page)
        {
            int pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            
            IEnumerable<NttmNews> items = db.News.OrderByDescending(x => x.NttmId);
            // Tìm kiếm 
            if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.NttmAlias.Contains(searchText) || x.NttmTitle.Contains(searchText));
            }

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        // Thêm mới 
        public ActionResult NttmAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NttmAdd(NttmNews model)
        {
            if(ModelState.IsValid)
            {
                model.NttmCreatedDate = DateTime.Now;
                model.NttmModifierDate = DateTime.Now;
                model.NttmCategoryId = 3;
                model.NttmAlias = K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Filter.FilterChar(model.NttmTitle);
                db.News.Add(model);
                db.SaveChanges();
                return RedirectToAction("NttmIndex");
            }
            return View(model);
        }

        //Sửa 
        public ActionResult NttmEdit(int id)
        {
            var item = db.News.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NttmEdit(NttmNews model)
        {
            if (ModelState.IsValid)
            {
                model.NttmCreatedDate = DateTime.Now;
                model.NttmModifierDate = DateTime.Now;
                model.NttmAlias = K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Filter.FilterChar(model.NttmTitle);
                
                db.News.Attach(model);
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
            var newsItem = db.News.Find(id);
            if (newsItem != null)
            {
                db.News.Remove(newsItem);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult IsActive(int id)
        {
            var newsItem = db.News.Find(id);
            if (newsItem != null)
            {
                newsItem.IsActive = !newsItem.IsActive;
                db.Entry(newsItem).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true , isActive = newsItem.IsActive });
            }
            return Json(new { success = false });
        }

        // Xóa tất cả 
        public ActionResult DeleteAll(string ids)
        {
            if(string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if(items!=null && items.Any()) { 
                    foreach(var item in items) {
                        var obj = db.News.Find(Convert.ToInt32(item));
                        db.News.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}