using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public class BEPriceListDetail
    {        
        public int COD_ARTI { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_ARTI1)]
        public string ALF_CODI_ARTI { get; set; }
        public string ALF_ARTI { get; set; }
        public int COD_LIST_PREC { get; set; }
        [Min(0.001, ErrorMessage = WhMessage.MsgReqNUM_PREC)]
        public decimal NUM_PREC { get; set; }
        public decimal NUM_DESC { get; set; }
        
        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
