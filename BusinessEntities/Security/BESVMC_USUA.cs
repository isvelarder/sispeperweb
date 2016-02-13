using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Security
{
    public class BESVMC_USUA
    {
        public string COD_USUA { get; set; }
        public int COD_SOCI_NEGO { get; set; }
        public int COD_PERF { get; set; }
        public string ALF_PERF { get; set; }
        public string ALF_PASS { get; set; }
        public string ALF_IMPU { get; set; }
        public decimal NUM_PORC_IMPU { get; set; }
        public bool IND_ACTI { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_NOMB { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }
        public bool IND_ERRO { get; set; }
        public string ALF_ERRO { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
