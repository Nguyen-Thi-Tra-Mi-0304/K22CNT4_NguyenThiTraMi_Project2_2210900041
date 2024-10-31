using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Controllers
{
    public class NttmMenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmMenu
        public ActionResult NttmIndex()
        {
            return View();
        }

        // Menu Top (Header)
        public ActionResult NttmMenuTop() {
            var items = db.Categories.OrderBy(x=>x.NttmPosition).ToList();
            return PartialView("_NttmMenuTop", items);
        }

        // Menu danh mục Sản Phẩm
        /*public ActionResult NttmMenuProductCategory()
        {
            var items = db.ProductCategories.ToList();
            return PartialView("_NttmMenuProductCategory", items);
        }*/

        // Menu danh mục => Sản phẩm (New Arrival)
        public ActionResult NttmNewArrivals()
        {
            var items = db.ProductCategories.ToList();
            return PartialView("_NttmNewArrivals", items);
        }

        // Menu trang sản phẩm 
        public ActionResult NttmMenuProductCategoryLeft(int? id)
        {
            if(id != null)
            {
                ViewBag.CateId = id;
            }
            var items = db.ProductCategories.ToList();
            return PartialView("_NttmMenuProductCategoryLeft", items);
        }
    }
}