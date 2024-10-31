using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_ProductImage")]
    public class NttmProductImage
    {
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        public int NttmProductId { get; set; }
        public string NttmImage { get; set; }
        public bool IsDefault { get; set; }

        public virtual NttmProduct NttmProduct { get; set; }

    }
}