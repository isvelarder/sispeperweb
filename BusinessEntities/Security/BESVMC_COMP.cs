using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Security
{
    public class BESVMC_COMP
    {
        public int COD_COMP { get; set; }
        public int COD_PAIS { get; set; }
        public string COD_DEPA { get; set; }
        public string COD_PROV { get; set; }
        public string COD_DIST { get; set; }
        public string ALF_COMP { get; set; }
        public string ALF_DESC { get; set; }
        public string ALF_DIRE_ENTR { get; set; }
        
        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
