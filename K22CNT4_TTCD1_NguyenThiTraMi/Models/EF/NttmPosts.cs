using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_Posts")]
    public class NttmPosts : NttmCommonAbstract
    {
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        [Required]
        [StringLength(150)]
        public string NttmTitle { get; set; }
        [StringLength(150)]
        public String NttmAlias { get; set; }
        public string NttmDescription { get; set; }
        [AllowHtml]
        public string NttmDetail { get; set; }
        [StringLength(250)]
        public string NttmImage { get; set; }
        public int NttmCategoryId { get; set; }
        [StringLength(250)]
        public string NttmSeoTitle { get; set; }
        [StringLength(500)]
        public string NttmSeoDescription { get; set; }
        [StringLength(200)]
        public string NttmSeoKeyWords { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }

        public virtual NttmCategory NttmCategory { get; set; }
    }
}