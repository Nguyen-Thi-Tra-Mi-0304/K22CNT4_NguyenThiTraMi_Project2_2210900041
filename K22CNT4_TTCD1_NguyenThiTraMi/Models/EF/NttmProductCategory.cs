using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_ProductCategory")]
    public class NttmProductCategory : NttmCommonAbstract
    {
        public NttmProductCategory()
        {
            this.NttmProducts = new HashSet<NttmProduct>();
        }
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        [Required]
        [StringLength(150)]
        public string NttmTitle { get; set; }
        [Required]
        [StringLength(150)]
        public String Alias { get; set; }
        public string NttmDescription { get; set; }
        [StringLength(250)]
        public string NttmIcon { get; set; }
        [StringLength(250)]
        public string NttmSeoTitle { get; set; }
        [StringLength(500)]
        public string NttmSeoDescription { get; set; }
        [StringLength(250)]
        public string NttmSeoKeyWords { get; set; }
        public int NttmPosition { get; set; }

        public ICollection<NttmProduct> NttmProducts { get; set; }
    }
}