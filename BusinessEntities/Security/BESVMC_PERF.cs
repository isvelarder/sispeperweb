using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Security
{
    public class BESVMC_PERF
    {
        public int COD_PERF { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_PERF { get; set; }
        public string ALF_DESC { get; set; }
        public BESVMD_ACCE OBJ_ACCE { get; set; }
        
        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }

        public BESVMC_PERF()
        {
            OBJ_ACCE = new BESVMD_ACCE();
        }
    }
}
