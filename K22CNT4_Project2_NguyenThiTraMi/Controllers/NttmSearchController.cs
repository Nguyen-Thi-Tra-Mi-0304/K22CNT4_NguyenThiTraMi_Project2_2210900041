using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K22CNT4_TTCD1_NguyenThiTraMi.Models.EF;
using PagedList.Mvc;
using PagedList;
using K22CNT4_TTCD1_NguyenThiTraMi.Models;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Controllers
{
    public class NttmSearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmSearch
        [HttpPost]
        public ActionResult ResultSearch(FormCollection f, int? page)
        {
            string tuKhoaTimKiem = f["txtTimKiem"];
            if (string.IsNullOrEmpty(tuKhoaTimKiem))
            {
                ViewBag.Error = "Vui lòng nhập từ khóa tìm kiếm!";
                // Nếu từ khóa trống, hiển thị toàn bộ sản phẩm
                var allProducts = db.Products.OrderByDescending(x => x.NttmCreatedDate);
                return View(allProducts.ToPagedList(page ?? 1, 8));
            }

            // Tìm kiếm sản phẩm với từ khóa
            var lstKQTK = db.Products
                            .Where(x => x.NttmTitle.Contains(tuKhoaTimKiem))
                            .OrderByDescending(x => x.NttmTitle);

            // Kiểm tra danh sách kết quả
            if (!lstKQTK.Any())
            {
                ViewBag.Error = "Không tìm thấy sản phẩm nào!";
                // Nếu không có kết quả, hiển thị toàn bộ sản phẩm
                var allProducts = db.Products.OrderByDescending(x => x.NttmCreatedDate);
                return View(allProducts.ToPagedList(page ?? 1, 8));
            }

            // Phân trang kết quả tìm kiếm
            int pageSize = 8;
            int pageIndex = page ?? 1;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageIndex;

            return View(lstKQTK.ToPagedList(pageIndex, pageSize));
        }
    }
}