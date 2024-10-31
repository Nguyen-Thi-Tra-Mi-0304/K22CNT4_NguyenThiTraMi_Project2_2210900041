using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_Contact")]
    public class NttmContact : NttmCommonAbstract
    {
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 kí tự")]
        public string NttmName { get; set; }
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 kí tự")]
        public string NttmWebsite { get; set; }
        public string NttmEmail { get; set; }
        [StringLength(4000)]
        public string NttmMessage { get; set; }
        public bool NttmIsRead { get; set; }

    }
}