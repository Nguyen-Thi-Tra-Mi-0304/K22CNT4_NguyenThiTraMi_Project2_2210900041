using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models.EF
{
    [Table("Tbl_SystemSetting")]
    public class NttmSystemSetting
    {
        [Key]
        [StringLength(50)]
        public string NttmSetting { get; set; }
        [StringLength(4000)]
        public string NttmSettingValue { get; set; }
        [StringLength(4000)]
        public string NttmSettingDescription { get; set; }
    }
}