using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public class BEModelArticle
    {
        public int? COD_MODE_ARTI { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_MODE_ARTI)]
        [StringLength(50, ErrorMessage = WhMessage.MsgLenALF_MODE_ARTI)]
        public string ALF_MODE_ARTI { get; set; }
        public string ALF_DESC { get; set; }
        public int? COD_COMP { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }

        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
