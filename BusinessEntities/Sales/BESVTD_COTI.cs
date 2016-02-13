using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Sales
{
    public class BESVTD_COTI
    {
        public int COD_COTI_DETA { get; set; }
        public int COD_COTI_GROU { get; set; }
        public int COD_COTI { get; set; }
        public int COD_ARTI { get; set; }
        public string ALF_NUME_GUIA { get; set; }
        public bool IND_MARC { get; set; }
        public string ALF_ARTI { get; set; }
        public string ALF_CODI_ARTI { get; set; }
        public decimal NUM_PREC_UNIT { get; set; }
        public decimal NUM_PORC_DESC { get; set; }
        public decimal NUM_DESC { get; set; }
        public int NUM_CANT { get; set; }
        public int NUM_CANT_DESP { get; set; }
        public int NUM_STOC_REAL { get; set; }
        public int NUM_STOC_VIRT { get; set; }
        public int NUM_STOC_COMP { get; set; }
        public int NUM_STOC_VIRT_COMP { get; set; }
        public int NUM_CANT_REAL_DISP { get; set; }
        public int NUM_CANT_REAL_COMP_PEDI { get; set; }
        public int NUM_CANT_VIRT_DISP { get; set; }
        public int NUM_CANT_VIRT_COMP_PEDI { get; set; }
        public decimal NUM_IMPO { get; set; }
        public int NUM_LINE { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int COD_TIPO_DOCU { get; set; }
        public int NUM_ACCI { get; set; }
    }
}
