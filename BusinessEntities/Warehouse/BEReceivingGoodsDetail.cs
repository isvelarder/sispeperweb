using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public class BEReceivingGoodsDetail
    {
        public int? COD_ALMA_RECE_DETA { get; set; }
        public int? COD_ALMA_RECE { get; set; }
        public int? COD_ARTI { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_ARTI1)]
        public string ALF_CODI_ARTI { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_ARTI1)]
        public string ALF_ARTI { get; set; }
        [Min(1, ErrorMessage = WhMessage.MsgMinNUM_CANT)]
        public int NUM_CANT { get; set; }
        public int NUM_CANT_MALO { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public int? COD_ALMA { get; set; }
        public int? COD_ALMA_TRAN { get; set; }

        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
