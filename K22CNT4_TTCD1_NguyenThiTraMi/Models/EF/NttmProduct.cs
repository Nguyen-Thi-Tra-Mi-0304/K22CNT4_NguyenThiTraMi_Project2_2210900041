using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_Product")]
    public class NttmProduct : NttmCommonAbstract
    {
        public NttmProduct() {
            this.NttmProductImages = new HashSet<NttmProductImage>();
            this.NttmOrderDetails = new HashSet<NttmOrderDetail>();
            this.ReviewProducts = new HashSet<ReviewProduct>();
        }
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        [Required]
        [StringLength(250)]
        public string NttmTitle { get; set; }
        [StringLength(250)]
        public String NttmAlias { get; set; }
        [StringLength(50)]
        public string NttmProductCode { get; set; }
        public string NttmDescription { get; set; }
        [AllowHtml]
        public string NttmDetail { get; set; }
        [StringLength(250)]
        public string NttmImage { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal NttmPrice { get; set; }
        public decimal NttmPriceSale { get; set; }
        public int NttmQuantity { get; set; }
        public int ViewCount { get; set; }
        public bool NttmIsHome { get; set; }
        public bool NttmIsSale { get; set; }
        public bool NttmIsFeature { get; set; }
        public bool NttmIsHot { get; set; }
        public bool IsActive { get; set; }
        public int NttmProductCategoryID { get; set; } // Khóa ngoại
        [StringLength(250)]
        public string NttmSeoTitle { get; set; }
        [StringLength(500)]
        public string NttmSeoDescription { get; set; }
        [StringLength(250)]
        public string NttmSeoKeyWords { get; set; }

        [ForeignKey("NttmProductCategoryID")]
        public virtual NttmProductCategory NttmProductCategory { get; set; } // Thuộc tính điều hướng
        public virtual ICollection<NttmProductImage> NttmProductImages { get; set; } // Thuộc tính điều hướng
        public virtual ICollection<NttmOrderDetail> NttmOrderDetails { get; set; } // Thuộc tính điều hướng
        public virtual ICollection<ReviewProduct> ReviewProducts { get; set; } // Thuộc tính điều hướng


    }
}