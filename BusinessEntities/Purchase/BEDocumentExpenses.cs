using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Purchase
{
    public class BEDocumentExpenses
    {
        public int COD_GANA { get; set; }
        public int COD_DOCU { get; set; }
        [Required(ErrorMessage = _Message.MsgReqEX_NUM_DOCU)]
        public string NUM_DOCU { get; set; }
        [Required(ErrorMessage = _Message.MsgReqEX_FEC_DOCU)]
        public DateTime? FEC_DOCU { get; set; }
        [Required(ErrorMessage = _Message.MsgReqEX_COD_CONC_GANA)]
        public int? COD_CONC_GANA { get; set; }
        public int COD_SOCI_NEGO { get; set; }
        [Required(ErrorMessage = _Message.MsgReqEX_ALF_NOMB_PROV)]
        public string ALF_NOMB_PROV { get; set; }
        [Required(ErrorMessage = _Message.MsgReqEX_ALF_RUCC_PROV)]
        public string ALF_RUCC_PROV { get; set; }
        [Required(ErrorMessage = _Message.MsgReqEX_COD_MONE)]
        public int? COD_MONE { get; set; }
        [Min(0.001, ErrorMessage = _Message.MsgMinEX_NUM_MONT)]
        public decimal NUM_MONT { get; set; }
        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
    }
}
