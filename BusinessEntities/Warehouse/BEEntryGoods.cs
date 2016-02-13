using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public class BEEntryGoods
    {
        public int? COD_ALMA_ENTR { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqFEC_ENTR)]
        public DateTime? FEC_ENTR { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqFEC_REGI)]
        public DateTime? FEC_REGI { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_ALMA)]
        public int? COD_ALMA { get; set; }
        public string ALF_ALMA { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqCOD_SOCI_NEGO_RESP)]
        public int? COD_SOCI_NEGO_RESP { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqCOD_MOTI)]
        public int? COD_MOTI { get; set; }
        public string ALF_COME { get; set; }
        public string ALF_DOCU_REFE { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public int COD_COMP { get; set; }

        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
