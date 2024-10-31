using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Controllers
{
    public class NttmSearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmSearch
        public ActionResult NttmIndex(string req)
        {
            if(string.IsNullOrEmpty(req))
            {
                return View("NoResult");
            }

            var result = db.Products.Where(x => x.NttmTitle.Contains(req)).ToList();

            if(result.Count == 0)
            {
                ViewBag.message = "Không tìm thấy sản phẩm bạn đang tìm kiếm!";
                return View("NoResult");
            }
            return View(result);
        }
    }
}