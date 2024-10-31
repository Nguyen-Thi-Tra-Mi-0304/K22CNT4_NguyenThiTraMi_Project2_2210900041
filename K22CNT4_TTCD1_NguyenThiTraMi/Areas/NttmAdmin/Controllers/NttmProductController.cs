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
    [Authorize(Roles = "Admin,Employee")]
    public class NttmProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmAdmin/NttmProduct
        public ActionResult NttmIndex(int? page)
        {
            IEnumerable<NttmProduct> items = db.Products.OrderByDescending(x => x.NttmId);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
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
            // Khởi tạo ViewBag với danh sách danh mục sản phẩm
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "NttmId", "NttmTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NttmAdd(NttmProduct model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                // Xử lý khi thêm mới ảnh thì lưu Vào bảng Product_Image
                if(Images != null && Images.Count > 0)
                {
                    for(int i = 0; i < Images.Count; i++)
                    {
                        if(i+1 == rDefault[0])
                        {
                            model.NttmImage = Images[i];
                            model.NttmProductImages.Add(new NttmProductImage
                            {
                                NttmProductId = model.NttmId,
                                NttmImage = Images[i],
                                IsDefault = true
                            }); 
                        }
                        else
                        {
                            model.NttmProductImages.Add(new NttmProductImage
                            {
                                NttmProductId = model.NttmId,
                                NttmImage = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }
                model.NttmCreatedDate = DateTime.Now;
                model.NttmModifierDate = DateTime.Now;
                if(string.IsNullOrEmpty(model.NttmSeoTitle))
                {
                    model.NttmSeoTitle = model.NttmTitle;
                }
                if (string.IsNullOrEmpty(model.NttmAlias))
                {
                    model.NttmAlias = K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Filter.FilterChar(model.NttmTitle);
                }
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("NttmIndex");
            }

            // Khởi tạo lại ViewBag.ProductCategory khi ModelState không hợp lệ
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "NttmId", "NttmTitle");

            return View(model);
        }

        // Sửa
        public ActionResult NttmEdit(int id)
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "NttmId", "NttmTitle");
            var item = db.Products.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NttmEdit(NttmProduct model)
        {
            if (ModelState.IsValid)
            {
                model.NttmCreatedDate = DateTime.Now;
                model.NttmModifierDate = DateTime.Now;
                model.NttmAlias = K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Filter.FilterChar(model.NttmTitle);

                db.Products.Attach(model);
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
            var newsItem = db.Products.Find(id);
            if (newsItem != null)
            {
                var checkImg = newsItem.NttmProductImages.Where(x => x.NttmProductId == newsItem.NttmId);
                if (checkImg != null)
                {
                    foreach (var img in checkImg)
                    {
                        db.ProductImages.Remove(img);
                        db.SaveChanges();
                    }
                }
                db.Products.Remove(newsItem);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // Trạng thái : Hoạt động / Không hoạt động 
        [HttpPost]
        public JsonResult IsActive(int id)
        {
            var newsItem = db.News.Find(id);
            if (newsItem != null)
            {
                newsItem.IsActive = !newsItem.IsActive;
                db.Entry(newsItem).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = newsItem.IsActive });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public JsonResult IsHome(int id)
        {
            var newsItem = db.Products.Find(id);
            if (newsItem != null)
            {
                newsItem.NttmIsHome = !newsItem.NttmIsHome;
                db.Entry(newsItem).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isHome = newsItem.NttmIsHome });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public JsonResult IsSale(int id)
        {
            var newsItem = db.Products.Find(id);
            if (newsItem != null)
            {
                newsItem.NttmIsSale = !newsItem.NttmIsSale;
                db.Entry(newsItem).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isSale = newsItem.NttmIsSale });
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
                        var obj = db.Products.Find(Convert.ToInt32(item));
                        db.Products.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}