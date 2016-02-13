using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Purchase
{
    public class BEDocumentLines
    {
        public int? COD_ORCO { get; set; }
        public int? COD_DOCU { get; set; }
        public int NUM_LINE { get; set; }
         [Required(ErrorMessage = _Message.MsgReqALF_CODI_ARTI)]
        public int? COD_ARTI { get; set; }
         public string ALF_CODI_ARTI { get; set; }
        public string ALF_ARTI { get; set; }
        [Min(1, ErrorMessage = _Message.MsgMinNUM_CANT)]
        public decimal NUM_CANT { get; set; }
        public decimal NUM_CANT_ABIE { get; set; }
        public decimal NUM_CANT_PERD { get; set; }
        public decimal NUM_PREC_UNIT_ORIG { get; set; }
        public decimal NUM_PREC_UNIT { get; set; }
        public decimal NUM_PORC_DESC { get; set; }
        public decimal NUM_DESC { get; set; }
        public decimal NUM_PREC_DESC { get; set; }
        public decimal NUM_IMPO { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }

        public int? TIP_DOCU_BASE { get; set; }
        public int? COD_DOCU_BASE { get; set; }
        public int? NUM_LINE_BASE { get; set; }
        public int? COD_ARTI_BASE { get; set; }

        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
