using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Generics
{
    public class BESVMC_PROY
    {
        public int COD_PROY { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_PROY { get; set; }

        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
