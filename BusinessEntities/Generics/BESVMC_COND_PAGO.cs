using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Generics
{
    public class BESVMC_COND_PAGO
    {
        public int COD_COND_PAGO { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_COND_PAGO { get; set; }
        public string ALF_DESC { get; set; }
        public int NUM_DIAS { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
