using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Generics
{
    public class BESVMC_TIPO_CONT
    {
        public int COD_TIPO_CONT { get; set; }
        public int COD_COMP { get; set; }
        public string ALF_TIPO_CONT { get; set; }
        public string ALF_DESC { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
