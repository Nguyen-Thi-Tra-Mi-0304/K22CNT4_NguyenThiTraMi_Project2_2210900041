using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using K22CNT4_TTCD1_NguyenThiTraMi.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<ReviewProduct> ReviewProducts { get; set; }
        public DbSet<ThongKe> ThongKes { get; set; }
        public DbSet<NttmCategory> Categories { get; set; }
        public DbSet<NttmAdv> Advs { get; set; }
        public DbSet<NttmPosts> Posts { get; set; }
        public DbSet<NttmNews> News { get; set; }
        public DbSet<NttmSystemSetting> SystemSettings { get; set; }
        public DbSet<NttmProductCategory> ProductCategories { get; set; }
        public DbSet<NttmProduct> Products { get; set; }
        public DbSet<NttmProductImage> ProductImages { get; set; }
        public DbSet<NttmContact> Contacts { get; set; }
        public DbSet<NttmOrder> Orders { get; set; }
        public DbSet<NttmOrderDetail> OrderDetails { get; set; }
        public DbSet<NttmSubscribe> Subscribes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}