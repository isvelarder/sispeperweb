using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Management
{
    public class BESVMD_SOCI_NEGO_CONT
    {
        public int COD_SOCI_NEGO_SUCU { get; set; }
        public int COD_SOCI_NEGO { get; set; }
        public int COD_TIPO_CONT { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_CONT { get; set; }
        public string ALF_EMAI { get; set; }
        public string ALF_TELE { get; set; }

        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
