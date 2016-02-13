using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public class BEReason
    {
        public int? COD_MOTI { get; set; }
        public int? COD_COMP { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_TIPO_MOTI)]
        public int? COD_TIPO_MOTI { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_MOTI)]
        [StringLength(50, ErrorMessage = WhMessage.MsgLenALF_MOTI)]
        public string ALF_MOTI { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }

        public int NUM_ACCI { get; set; }
        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
