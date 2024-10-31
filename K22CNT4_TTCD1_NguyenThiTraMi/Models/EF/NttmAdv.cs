using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_Adv")]
    public class NttmAdv : NttmCommonAbstract
    {
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        [Required]
        [StringLength(150)]
        public string NttmTitle { get; set; }
        [StringLength(500)]
        public string NttmDescription { get; set; }
        [StringLength(500)]
        public string NttmImage { get; set; }
        [StringLength(500)]
        public string NttmLink { get; set; }
        public int NttmType { get; set; }

    }
}