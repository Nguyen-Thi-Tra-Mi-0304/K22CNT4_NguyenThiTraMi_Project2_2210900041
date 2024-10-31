using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K22CNT4_TTCD1_NguyenThiTraMi.Models.EF;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Areas.NttmAdmin.Controllers
{
    public class NttmSettingSystemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NttmAdmin/SettingSystem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Partial_Setting()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddSetting(SettingSystemViewModel req)
        {
            NttmSystemSetting set = null;
            var checkTitle = db.SystemSettings.FirstOrDefault(x => x.NttmSetting.Contains("SettingTitle"));
            if (checkTitle == null)
            {
                set = new NttmSystemSetting();
                set.NttmSetting = "SettingTitle";
                set.NttmSettingValue = req.SettingTitle;
                db.SystemSettings.Add(set);
            }
            else
            {
                checkTitle.NttmSettingValue = req.SettingTitle;
                db.Entry(checkTitle).State = System.Data.Entity.EntityState.Modified;
            }
            //logo
            var checkLogo = db.SystemSettings.FirstOrDefault(x => x.NttmSetting.Contains("SettingLogo"));
            if (checkLogo == null)
            {
                set = new NttmSystemSetting();
                set.NttmSetting = "SettingLogo";
                set.NttmSettingValue = req.SettingLogo;
                db.SystemSettings.Add(set);
            }
            else
            {
                checkLogo.NttmSettingValue = req.SettingLogo;
                db.Entry(checkLogo).State = System.Data.Entity.EntityState.Modified;
            }
            //Email
            var email = db.SystemSettings.FirstOrDefault(x => x.NttmSetting.Contains("SettingEmail"));
            if (email == null)
            {
                set = new NttmSystemSetting();
                set.NttmSetting = "SettingEmail";
                set.NttmSettingValue = req.SettingEmail;
                db.SystemSettings.Add(set);
            }
            else
            {
                email.NttmSettingValue = req.SettingEmail;
                db.Entry(email).State = System.Data.Entity.EntityState.Modified;
            }
            //Hotline
            var Hotline = db.SystemSettings.FirstOrDefault(x => x.NttmSetting.Contains("SettingHotline"));
            if (Hotline == null)
            {
                set = new NttmSystemSetting();
                set.NttmSetting = "SettingHotline";
                set.NttmSettingValue = req.SettingHotline;
                db.SystemSettings.Add(set);
            }
            else
            {
                Hotline.NttmSettingValue = req.SettingHotline;
                db.Entry(Hotline).State = System.Data.Entity.EntityState.Modified;
            }
            //TitleSeo
            var TitleSeo = db.SystemSettings.FirstOrDefault(x => x.NttmSetting.Contains("SettingTitleSeo"));
            if (TitleSeo == null)
            {
                set = new NttmSystemSetting();
                set.NttmSetting = "SettingTitleSeo";
                set.NttmSettingValue = req.SettingTitleSeo;
                db.SystemSettings.Add(set);
            }
            else
            {
                TitleSeo.NttmSettingValue = req.SettingTitleSeo;
                db.Entry(TitleSeo).State = System.Data.Entity.EntityState.Modified;
            }
            //DessSeo
            var DessSeo = db.SystemSettings.FirstOrDefault(x => x.NttmSetting.Contains("SettingDesSeo"));
            if (DessSeo == null)
            {
                set = new NttmSystemSetting();
                set.NttmSetting = "SettingDesSeo";
                set.NttmSettingValue = req.SettingDesSeo;
                db.SystemSettings.Add(set);
            }
            else
            {
                DessSeo.NttmSettingValue = req.SettingDesSeo;
                db.Entry(DessSeo).State = System.Data.Entity.EntityState.Modified;
            }
            //KeySeo
            var KeySeo = db.SystemSettings.FirstOrDefault(x => x.NttmSetting.Contains("SettingKeySeo"));
            if (KeySeo == null)
            {
                set = new NttmSystemSetting();
                set.NttmSetting = "SettingKeySeo";
                set.NttmSettingValue = req.SettingKeySeo;
                db.SystemSettings.Add(set);
            }
            else
            {
                KeySeo.NttmSettingValue = req.SettingKeySeo;
                db.Entry(KeySeo).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();

            return View("Partial_Setting");
        }
    }

    
}