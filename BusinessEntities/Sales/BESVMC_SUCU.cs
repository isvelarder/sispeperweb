using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Sales
{
    public class BESVMC_SUCU
    {
        public int COD_SUCU { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_SUCU { get; set; }
        public string ALF_DESC { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
