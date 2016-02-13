using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Warehouse
{
    public class BESVMC_ARTI
    {
        public int COD_ARTI { get; set; }
        public int COD_COMP { get; set; }
        public int COD_TIPO_ARTI { get; set; }
        public string ALF_TIPO_ARTI { get; set; }
        public int COD_MODE_ARTI { get; set; }
        public string ALF_MODE_ARTI { get; set; }
        public string ALF_ARTI { get; set; }
        public string ALF_CODI_ARTI { get; set; }
        public string ALF_DESC { get; set; }
        public int NUM_STOC_MINI { get; set; }
        public decimal NUM_PREC { get; set; }
        public decimal NUM_DESC { get; set; }
        public byte[] IMG_FOTO { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
