using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Sales
{
    public class BESVTC_OVEN
    {
        public BESVTC_OVEN()
        {
            LST_OVEN = new List<BESVTD_OVEN>();
            LST_OVEN_ARTI_GROU = new List<BESVTD_OVEN>();
            LST_OVEN_GROU = new List<BESVTD_OVEN_GROU>();
        }

        public int COD_OVEN { get; set; }
        public int COD_COTI { get; set; }
        public int COD_ESTA { get; set; }
        public int COD_COMP { get; set; }
        public int COD_MONE { get; set; }
        public int COD_SUCU { get; set; }
        public int COD_SOCI_NEGO { get; set; }
        public string ALF_NOMB { get; set; }
        public DateTime? FEC_REGI { get; set; }
        public DateTime? FEC_DOCU { get; set; }
        public DateTime? FEC_PAGO { get; set; }
        public string ALF_DIRE { get; set; }
        public string ALF_CONT { get; set; }
        public decimal NUM_DESC { get; set; }
        public string ALF_OBSE { get; set; }
        public decimal NUM_SUBT { get; set; }
        public decimal NUM_IGVV { get; set; }
        public decimal NUM_ISCC { get; set; }
        public decimal NUM_TOTA { get; set; }
        public string ALF_TOTA { get; set; }

        public string ALF_NUME_IDENT { get; set; }
        public DateTime? FEC_DESD { get; set; }
        public DateTime? FEC_HAST { get; set; }

        public List<BESVTD_OVEN> LST_OVEN { get; set; }
        public List<BESVTD_OVEN_GROU> LST_OVEN_GROU { get; set; }
        public List<BESVTD_OVEN> LST_OVEN_ARTI_GROU { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }
    }
}
