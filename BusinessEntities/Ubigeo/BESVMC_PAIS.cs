using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Ubigeo
{
    public class BESVMC_PAIS
    {
        public int COD_PAIS { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_PAIS { get; set; }
        public string ALF_IMPU { get; set; }
        public decimal NUM_PORC_IMPU { get; set; }
        public string ALF_DESC { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
