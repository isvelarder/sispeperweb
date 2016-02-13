using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Management
{
    public class BESVMD_SOCI_NEGO_SUCU
    {
        public int COD_SOCI_NEGO_SUCU { get; set; }
        public int COD_SOCI_NEGO { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_SUCU { get; set; }
        public string ALF_DIRE { get; set; }
        public int COD_PAIS { get; set; }
        public string ALF_PAIS { get; set; }
        public string COD_DEPA { get; set; }
        public string ALF_DEPA { get; set; }
        public string COD_PROV { get; set; }
        public string ALF_PROV { get; set; }
        public string COD_DIST { get; set; }
        public string ALF_DIST { get; set; }

        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
