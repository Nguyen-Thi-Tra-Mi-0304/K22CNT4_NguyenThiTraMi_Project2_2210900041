using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using K22CNT4_TTCD1_NguyenThiTraMi.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Controllers
{
    public class NewsController : Controller


    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: News
        public ActionResult Index(int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<NttmNews> items = db.News.OrderByDescending(x => x.NttmId);
            
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Detail(int id)
        {
            var item = db.News.Find(id);
            return View(item);
        }

        // Tin tức trên trang chủ 
        public ActionResult Partial_News_Home()
        {
            var items = db.News.Take(3).ToList();
            return PartialView(items);
        }
    }
}