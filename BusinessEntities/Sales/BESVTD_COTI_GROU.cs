using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Sales
{
    public class BESVTD_COTI_GROU
    {
        public int COD_COTI_GROU { get; set; }
        public int COD_COTI { get; set; }
        public string ALF_NOMB { get; set; }
        public int NUM_CANT { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int COD_TIPO_DOCU { get; set; }
        public int NUM_ACCI { get; set; }
    }
}
