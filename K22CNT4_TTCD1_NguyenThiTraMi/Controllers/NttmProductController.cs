using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Controllers
{
    public class NttmProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmProduct
        public ActionResult NttmIndex()
        {
            var items = db.Products.ToList();
            return View(items);
        }
        // Chi tiết sản phẩm
        public ActionResult NttmDetail(string alias, int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                db.Entry(item).Property(x => x.ViewCount).IsModified = true;
                db.SaveChanges();
            }

            // Đếm số lượng đánh giá
            var reviews = db.ReviewProducts.Where(x => x.ProductId == id).ToList();
            ViewBag.CountReview = reviews.Count;

            // Tính giá trị trung bình của đánh giá
            if (reviews != null && reviews.Count > 0) // Kiểm tra null và Count
            {
                ViewBag.AverageRating = (int)Math.Round(reviews.Average(r => r.Rate)); // Làm tròn giá trị trung bình
            }
            else
            {
                ViewBag.AverageRating = 0;
            }

            return View(item);
        }
        // Trang sản phẩm
        public ActionResult NttmProductCategory(string alias, int? id)
        {
            var items = db.Products.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.NttmProductCategoryID == id).ToList();
            }
            var cate = db.ProductCategories.Find(id);
            if(cate !=  null)
            {
                ViewBag.CateName = cate.NttmTitle;
            }
            ViewBag.CateId = id;
            return View(items);
        }

        public ActionResult NttmPartial_ItemByCateId()
        {
            var items = db.Products.Where(x=>x.NttmIsHome && x.IsActive).Take(15).ToList();
            return PartialView(items);
        }

        public ActionResult NttmPartial_ProductSales()
        {
            var items = db.Products.Where(x => x.NttmIsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }

 
    }
}