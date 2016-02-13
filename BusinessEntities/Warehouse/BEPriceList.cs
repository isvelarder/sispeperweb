using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public class BEPriceList
    {
        public int COD_LIST_PREC { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_LIST_PREC)]
        public string ALF_LIST_PREC { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqIND_TIPO_LIST)]
        public int? IND_TIPO_LIST { get; set; }
        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public int COD_COMP { get; set; }

        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
