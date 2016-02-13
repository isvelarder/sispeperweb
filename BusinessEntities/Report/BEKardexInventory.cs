using BusinessEntities.Purchase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Report
{
    public class BEKardexInventory
    {
        [Required(ErrorMessage = _Message.MsgReqALF_ALMA)]
        public string COD_ALMA { get; set; }
        public string ALF_ALMA { get; set; }
        public string ALF_CODI_ARTI { get; set; }
        public string ALF_ARTI { get; set; }
        public int NUM_STOC_REAL { get; set; }
        public int CAN_MOVI { get; set; }
        public int NUM_STOC_FINA { get; set; }
        public decimal NUM_COST_UNIT { get; set; }
        public decimal NUM_COST_VALO { get; set; }
        public DateTime FEC_OPER { get; set; }
        public string IND_OPER_STOC { get; set; }
        public int COD_DOCU { get; set; }
        public int COD_COMP { get; set; }

        public DateTime? FEC_OPER_INIC { get; set; }
        public DateTime? FEC_OPER_FINA { get; set; }
    }
}
