using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_News")]
    public class NttmNews : NttmCommonAbstract
    {
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        [Required(ErrorMessage = "Không để trống tiêu đề tin")]
        [StringLength(150)]
        public string NttmTitle { get; set; }
        public String NttmAlias { get; set; }
        public string NttmDescription { get; set; }
        [AllowHtml]
        public string NttmDetail { get; set; }
        public string NttmImage { get; set; }
        public int NttmCategoryId { get; set; }
        public string NttmSeoTitle { get; set; }
        public string NttmSeoDescription { get; set; }
        public string NttmSeoKeyWords { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }

        // Thuộc tính điều hướng
        public virtual NttmCategory NttmCategory { get; set; }
    }
}