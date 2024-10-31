using K22CNT4_TTCD1_NguyenThiTraMi.Models;
using K22CNT4_TTCD1_NguyenThiTraMi.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ShoppingCartController()
        {
        }

        public ShoppingCartController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: ShoppingCart
        [AllowAnonymous]
        public ActionResult Index()
        {
            
            return View();
        }
        // Thanh toán 
        [AllowAnonymous]
        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult CheckOutSuccess()
        {
            return View();
        }

        //Phân trang giỏ hàng Item
        [AllowAnonymous]
        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }

        // Thanh toán 
        [AllowAnonymous]
        public ActionResult Partial_Item_ThanhToan()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult Partial_CheckOut()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            if(user != null)
            {
                ViewBag.User = user;
            }
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return Json(new { Count = cart.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }

        // Đặt hàng 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CheckOut(OrderViewModel req)
        {
            var code = new { Success = false, Code = -1 };
            if (ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null)
                {
                    NttmOrder order = new NttmOrder();
                    order.NttmCustomerName = req.CustomerName;
                    order.NttmPhone = req.Phone;
                    order.NttmAddress = req.Address;
                    /*order.NttmEmail = req.Email;*/
                    cart.Items.ForEach(x => order.NttmOrderDetails.Add(new NttmOrderDetail
                    {
                        NttmProductId = x.ProductId,
                        NttmQuantity = x.Quantity,
                        NttmPrice = x.Price
                    }));
                    order.NttmTotalAmount = cart.Items.Sum(x => (x.Price * x.Quantity));
                    order.TypePayment = req.TypePayment;
                    order.NttmCreatedDate = DateTime.Now;
                    order.NttmModifierDate = DateTime.Now;
                    order.NttmCreatedBy = req.Phone;

                    if (User.Identity.IsAuthenticated)
                    {
                        order.CustomerId = User.Identity.GetUserId();
                    }
                    Random rd = new Random();
                    order.NttmCode = "DH" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
                    db.Orders.Add(order);
                    db.SaveChanges();

                    //gửi mail cho khach hang khi dat hang thanh cong 
                    var strSanPham = "";
                    var thanhtien = decimal.Zero;
                    var TongTien = decimal.Zero;

                    foreach (var sp in cart.Items)
                    {
                        strSanPham += "<tr>";
                        strSanPham += "<td>" + sp.ProductName + "</td>";
                        strSanPham += "<td>" + sp.Quantity + "</td>";
                        strSanPham += "<td>" + K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Common.FormatNumber(sp.TotalPrice, 0) + "</td>";
                        strSanPham += "</tr>";
                        thanhtien += sp.Price * sp.Quantity;
                    }
                    TongTien = thanhtien;

                    string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/send2.html"));
                    contentCustomer = contentCustomer.Replace("{{MaDon}}", order.NttmCode);
                    contentCustomer = contentCustomer.Replace("{{SanPham}}", strSanPham);
                    contentCustomer = contentCustomer.Replace("{{NgayDat}}", DateTime.Now.ToString("dd/MM/yyyy"));
                    contentCustomer = contentCustomer.Replace("{{TenKhachHang}}", order.NttmCustomerName);
                    contentCustomer = contentCustomer.Replace("{{Phone}}", order.NttmPhone);
                    contentCustomer = contentCustomer.Replace("{{Email}}", req.Email);
                    contentCustomer = contentCustomer.Replace("{{DiaChiNhanHang}}", order.NttmAddress);
                    contentCustomer = contentCustomer.Replace("{{ThanhTien}}", K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Common.FormatNumber(thanhtien, 0));
                    contentCustomer = contentCustomer.Replace("{{TongTien}}", K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Common.FormatNumber(TongTien, 0));
                    K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Common.SendMail("MonaSaiGon", "Đơn hàng #" + order.NttmCode, contentCustomer.ToString(), req.Email);

                    string contentAdmin = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/send1.html"));
                    contentAdmin = contentAdmin.Replace("{{MaDon}}", order.NttmCode);
                    contentAdmin = contentAdmin.Replace("{{SanPham}}", strSanPham);
                    contentAdmin = contentAdmin.Replace("{{NgayDat}}", DateTime.Now.ToString("dd/MM/yyyy"));
                    contentAdmin = contentAdmin.Replace("{{TenKhachHang}}", order.NttmCustomerName);
                    contentAdmin = contentAdmin.Replace("{{Phone}}", order.NttmPhone);
                    contentAdmin = contentAdmin.Replace("{{Email}}", req.Email);
                    contentAdmin = contentAdmin.Replace("{{DiaChiNhanHang}}", order.NttmAddress);
                    contentAdmin = contentAdmin.Replace("{{ThanhTien}}", K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Common.FormatNumber(thanhtien, 0));
                    contentAdmin = contentAdmin.Replace("{{TongTien}}", K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Common.FormatNumber(TongTien, 0));
                    K22CNT4_TTCD1_NguyenThiTraMi.Models.Common.Common.SendMail("ShopOnline", "Đơn hàng mới #" + order.NttmCode, contentAdmin.ToString(), ConfigurationManager.AppSettings["EmailAdmin"]);

                    cart.ClearCart();
                    return RedirectToAction("CheckOutSuccess");
                }
            }
                return Json(code);
        }

        // Thêm sản phẩm vào giỏ hàng
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            var db = new ApplicationDbContext();
            var checkProduct = db.Products.FirstOrDefault(x => x.NttmId == id);
            if (checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    ProductId = checkProduct.NttmId,
                    ProductName = checkProduct.NttmTitle,
                    CategoryName = checkProduct.NttmProductCategory.NttmTitle,
                    Alias = checkProduct.NttmAlias,
                    Quantity = quantity
                };
                if (checkProduct.NttmProductImages.FirstOrDefault(x => x.IsDefault) != null)
                {
                    item.ProductImg = checkProduct.NttmProductImages.FirstOrDefault(x => x.IsDefault).NttmImage;
                }
                item.Price = checkProduct.NttmPrice;
                if (checkProduct.NttmPriceSale > 0)
                {
                    item.Price = (decimal)checkProduct.NttmPriceSale;
                }
                item.TotalPrice = item.Quantity * item.Price;
                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giở hàng thành công!", code = 1, Count = cart.Items.Count };
            }
            return Json(code);
        }

        // Update Cập nhật 
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuantity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        // Xóa sản phẩm trong giỏ hàng 
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };

            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.Items.FirstOrDefault(x => x.ProductId == id);
                if (checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };
                }
            }
            return Json(code);
        }

        // Xóa tất cả sản phẩm 
        [AllowAnonymous]
        [HttpPost]
        public ActionResult DeleteAll()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.ClearCart();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
    }
}