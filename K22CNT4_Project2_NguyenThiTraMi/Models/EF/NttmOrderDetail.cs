using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_OrderDetail")]
    public class NttmOrderDetail
    {
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        public int NttmOrderId { get; set; }
        public int NttmProductId { get; set; }
        public decimal NttmPrice { get; set; }
        public int NttmQuantity { get; set; }

        public virtual NttmOrder NttmOrders { get; set; }
        public virtual NttmProduct NttmProducts { get; set; }
    }
}