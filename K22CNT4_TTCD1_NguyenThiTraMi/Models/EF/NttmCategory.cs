using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_Category")]
    public class NttmCategory : NttmCommonAbstract
    {
        public NttmCategory() 
        {
            this.NttmNews = new HashSet<NttmNews>();
        }
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống!")]
        [StringLength(150)]
        public string NttmTitle { get; set; }
        public String NttmAlias { get; set; }
        /*[StringLength(150)]
        public String TypeCode { get; set; }*/
        public String Link { get; set; }
        public string NttmDescription { get; set; }
        [StringLength(150)]
        public string NttmSeoTitle { get; set; }
        [StringLength(150)]
        public string NttmSeoDescription { get; set; }
        [StringLength(150)]
        public string NttmSeoKeyWords { get; set; }
        public int NttmPosition { get; set; }
        public bool IsActive { get; set; }

        public ICollection<NttmNews> NttmNews { get; set; }
        public ICollection<NttmPosts> NttmPosts { get; set; }
    }
}