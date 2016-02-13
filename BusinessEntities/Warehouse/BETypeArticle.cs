using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public class BETypeArticle
    {
        public int? COD_TIPO_ARTI { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_TIPO_ARTI)]
        [StringLength(50, ErrorMessage = WhMessage.MsgLenALF_TIPO_ARTI)]
        public string ALF_TIPO_ARTI { get; set; }
        public string ALF_DESC { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }

        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
