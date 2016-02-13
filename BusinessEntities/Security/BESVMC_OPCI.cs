using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Security
{
    public class BESVMC_OPCI
    {
        public int COD_OPCI { get; set; }
        public int COD_PERF { get; set; }
        public int COD_MAIN { get; set; }
        public int COD_OBJE_OPCI { get; set; }
        public int COD_MAIN_MENU { get; set; }
        public string ALF_NOMB { get; set; }
        public string ALF_DESC { get; set; }
        public string ALF_WHEN_URLL { get; set; }
        public string ALF_TEMP_URLL { get; set; }
        public string ALF_CONT_URLL { get; set; }
        public string ALF_DESC_MOST_FORM { get; set; }
        public string ALF_DESC_MOST_GRUP { get; set; }
        public string ALF_DIRE_URLL_MVCC { get; set; }

        public bool IND_MARC { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
