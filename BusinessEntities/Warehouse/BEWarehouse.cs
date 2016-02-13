using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public class BEWarehouse
    {
        public int? COD_ALMA { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_ALMA)]
        [StringLength(150, ErrorMessage = WhMessage.MsgLenALF_ALMA)]
        public string ALF_ALMA { get; set; }
        public string ALF_DESC { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqCOD_SOCI_NEGO_ENCA)]
        public int? COD_SOCI_NEGO_ENCA { get; set; }
        public int? COD_COMP { get; set; }
        public string ALF_NOMB { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }

        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
        public int NUM_ACCI { get; set; }
    }
}
