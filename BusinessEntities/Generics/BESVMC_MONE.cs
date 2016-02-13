using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Generics
{
    public class BESVMC_MONE
    {
        public int COD_MONE { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_MONE { get; set; }
        public string ALF_MONE_SIMB { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
