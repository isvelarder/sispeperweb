using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Security
{
    public class BESVMC_MAIN_MENU
    {
        public int COD_MAIN { get; set; }
        public string ALF_NOMB { get; set; }
        public string ALF_DESC { get; set; }
        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
