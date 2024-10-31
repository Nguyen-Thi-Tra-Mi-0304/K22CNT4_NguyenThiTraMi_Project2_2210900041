using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_Order")]
    public class NttmOrder : NttmCommonAbstract
    {
        public NttmOrder() 
        {
            this.NttmOrderDetails = new HashSet<NttmOrderDetail>();
        }
        [Key] // khóa chính 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // tự động tăng 
        public int NttmId { get; set; }
        [Required]
        public string NttmCode { get; set; }
        [Required(ErrorMessage ="Tên khách hàng không để trống")]
        public string NttmCustomerName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không để trống")]
        public string NttmPhone { get; set; }
        [Required(ErrorMessage = "Địa chỉ không để trống")]
        public string NttmAddress { get; set; }
        public string Email { get; set; }
        public decimal NttmTotalAmount { get; set; }
        public int NttmQuantity { get; set; }
        public int TypePayment { get; set; }
        public string CustomerId { get; set;}

        public virtual ICollection<NttmOrderDetail> NttmOrderDetails { get; set; }

    }
}