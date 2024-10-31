using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace K22CNT4_TTCD1_NguyenThiTraMi.Areas.NttmAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NttmOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmAdmin/NttmOrder
        public ActionResult NttmIndex(int? page)
        {
            var items = db.Orders.OrderByDescending(x => x.NttmCreatedDate).ToList();

            if (page == null)
            {
                page = 1;
            }
            var pageNumber = page ?? 1;
            var pageSize = 10;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageNumber;
            return View(items.ToPagedList(pageNumber, pageSize));
        }

        // Nút xem - Chi tiết đơn hàng 
        public ActionResult NttmView(int id)
        {
            var item = db.Orders.Find(id);
            return View(item);
        }
        public ActionResult NttmPartial_SanPham(int id)
        {
            var items = db.OrderDetails.Where(x => x.NttmOrderId == id).ToList();
            return PartialView(items);
        }
        [HttpPost]
        public ActionResult NttmUpdateTT(int id, int trangthai)
        {
            var item = db.Orders.Find(id);
            if (item != null)
            {
                db.Orders.Attach(item);
                item.TypePayment = trangthai;
                db.Entry(item).Property(x => x.TypePayment).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }
    }
}