using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Areas.NttmAdmin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class HomeController : Controller
    {
        // GET: NttmAdmin/NttmHome
        public ActionResult Index()
        {
            return View();
        }
    }
}