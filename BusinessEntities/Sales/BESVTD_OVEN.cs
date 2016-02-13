using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Sales
{
    public class BESVTD_OVEN
    {
        public int COD_OVEN_DETA { get; set; }
        public int COD_OVEN_GROU { get; set; }
        public int COD_OVEN { get; set; }
        public int COD_ARTI { get; set; }
        public string ALF_ARTI { get; set; }
        public string ALF_CODI_ARTI { get; set; }
        public decimal NUM_PREC_UNIT { get; set; }
        public decimal NUM_PORC_DESC { get; set; }
        public decimal NUM_DESC { get; set; }
        public int NUM_CANT { get; set; }
        public int NUM_STOC_REAL { get; set; }
        public int NUM_STOC_VIRT { get; set; }
        public decimal NUM_IMPO { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
