using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_NguyenThiTraMi.Models
{
    public class NttmCommonAbstract
    {
        public string NttmCreatedBy { get; set; }
        public DateTime NttmCreatedDate { get; set; }
        public DateTime NttmModifierDate { get; set; }
        public string NttmModifierBy { get; set; }
    }
}