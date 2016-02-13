using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Management
{
    public class BESVMC_TIPO_CAMB
    {
        public int COD_TIPO_CAMB { get; set; }
        public int COD_COMP { get; set; }
        public DateTime? FEC_TIPO_CAMB { get; set; }
        public decimal NUM_TIPO_CAMB_COMP { get; set; }
        public decimal NUM_TIPO_CAMB_VENT { get; set; }

        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
