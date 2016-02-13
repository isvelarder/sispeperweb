using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public class BEArticle
    {
        public int COD_ARTI { get; set; }
        public int COD_TIPO_ARTI { get; set; }
        public int COD_MODE_ARTI { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_ARTI)]
        [StringLength(50, ErrorMessage = WhMessage.MsgLenALF_ARTI)]
        public string ALF_ARTI { get; set; }
        [Required(ErrorMessage = WhMessage.MsgReqALF_CODI_ARTI)]
        [StringLength(30, ErrorMessage = WhMessage.MsgLenALF_CODI_ARTI)]
        public string ALF_CODI_ARTI { get; set; }
        public string ALF_DESC { get; set; }
        public int NUM_STOC_MINI { get; set; }
        public byte[] IMG_FOTO { get; set; }
        public int? COD_COMP { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public int? COD_ALMA { get; set; }
        public decimal NUM_PREC { get; set; }
        public decimal NUM_DESC { get; set; }

        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
