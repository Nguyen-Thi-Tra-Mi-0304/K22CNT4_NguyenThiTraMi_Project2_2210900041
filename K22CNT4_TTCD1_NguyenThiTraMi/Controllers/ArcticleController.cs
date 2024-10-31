using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Controllers
{
    public class ArcticleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Arcticle
        public ActionResult Index(string alias)
        {
            var item = db.Posts.FirstOrDefault(x => x.NttmAlias == alias);
            return View(item);
        }
    }
}