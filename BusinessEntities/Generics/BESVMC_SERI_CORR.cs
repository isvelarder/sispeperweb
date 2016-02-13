using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Generics
{
    public class BESVMC_SERI_CORR
    {
        public int COD_TIPO_DOCU { get; set; }
        public string ALF_TIPO_DOCU { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_SERI { get; set; }
        public int NUM_CORR { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
