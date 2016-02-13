using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Security
{
    public class BESVMD_ACCE
    {
        public int COD_ACCE { get; set; }
        public int COD_BUTT { get; set; }
        public int COD_MAIN { get; set; }
        public int COD_OPCI { get; set; }
        public int COD_PERF { get; set; }
        public string ALF_NOMB { get; set; }
        public string ALF_PERF { get; set; }
        public string ALF_DESC { get; set; }
        public bool IND_MARC { get; set; }
        public byte[] IMG_BUTT { get; set; }

        public List<BESVMC_OPCI> LST_OPCI { get; set; }
        public List<BESVMC_BUTT> LST_OPCI_BUTT { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
