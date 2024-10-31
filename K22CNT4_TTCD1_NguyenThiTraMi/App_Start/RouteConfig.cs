using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace K22CNT4_TTCD1_NguyenThiTraMi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "NttmContact", action = "NttmIndex", alias = UrlParameter.Optional },
                namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
            );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "CheckOut",
                url: "thanh-toan",
                defaults: new { controller = "ShoppingCart", action = "CheckOut", alias = UrlParameter.Optional },
                namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
            );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "ShoppingCart",
                url: "gio-hang",
                defaults: new { controller = "ShoppingCart", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
            );
            routes.MapRoute(
            name: "BaiViet",
            url: "post/{alias}",
            defaults: new { controller = "Arcticle", action = "Index", alias = UrlParameter.Optional },
            namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
        );
            routes.MapRoute(
                name: "CategoryProduct",
                url: "danh-muc-san-pham/{alias}-{id}",
                defaults: new { controller = "NttmProduct", action = "NttmProductCategory", id = UrlParameter.Optional },
                namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
            );
            routes.MapRoute(
                name: "DetailProducts",
                url: "chi-tiet/{alias}-p{id}",
                defaults: new { controller = "NttmProduct", action = "NttmDetail", alias = UrlParameter.Optional },
                namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
            );

            routes.MapRoute(
                name: "Products",
                url: "san-pham",
                defaults: new { controller = "NttmProduct", action = "NttmIndex", alias = UrlParameter.Optional },
                namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
            );
            routes.MapRoute(
                  name: "DetailNew",
                  url: "{alias}-n{id}",
                  defaults: new { controller = "News", action = "Detail", id = UrlParameter.Optional },
                  namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
            );
            routes.MapRoute(
                name: "NewsList",
                url: "tin-tuc",
                defaults: new { controller = "News", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "K22CNT4_TTCD1_NguyenThiTraMi.Controllers" }
            );
        }
    }
}
