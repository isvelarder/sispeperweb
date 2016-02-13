using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Sales
{
    public class BESVTC_COTI
    {
        public BESVTC_COTI()
        {
            LST_COTI = new List<BESVTD_COTI>();
            LST_COTI_ARTI_GROU = new List<BESVTD_COTI>();
            LST_COTI_GROU = new List<BESVTD_COTI_GROU>();
            LST_COTI_DETA = new List<BESVTD_COTI>();
            LST_GREM = new List<BESVTC_COTI>();
            LST_DVEN = new List<BESVTC_COTI>();
        }

        public int COD_DOCU_INIC { get; set; }
        public int COD_DOCU_SECU { get; set; }
        public int COD_COTI { get; set; }
        public int COD_NCRE { get; set; }
        public int COD_PROY { get; set; }
        public int COD_OVEN { get; set; }
        public int COD_GREM { get; set; }
        public int COD_DVEN { get; set; }
        public int COD_ESTA { get; set; }
        public int COD_ALMA { get; set; }
        public string COD_SEMM_REPO { get; set; }
        public decimal NUM_SUBT_COTI { get; set; }
        public decimal NUM_SUBT_OVEN { get; set; }
        public decimal NUM_SUBT_DVEN { get; set; }
        public decimal NUM_MONT_SEM1 { get; set; }
        public decimal NUM_MONT_SEM2 { get; set; }
        public string ALF_ESTA { get; set; }
        public string ALF_PROY { get; set; }
        public string ALF_NUME_DOCU { get; set; }
        public string ALF_NUME_GUIA { get; set; }
        public string ALF_NUME_SUNA { get; set; }
        public string ALF_DIRE_FISC { get; set; }
        public bool IND_MARC { get; set; }
        public bool IND_KITS { get; set; }
        public bool IND_FACT { get; set; }
        public int COD_COMP { get; set; }
        public int COD_MONE { get; set; }
        public int COD_SUCU { get; set; }
        public int COD_SOCI_NEGO { get; set; }
        public string ALF_NOMB { get; set; }
        public DateTime? FEC_REGI { get; set; }
        public DateTime? FEC_DOCU { get; set; }
        public DateTime? FEC_VENC { get; set; }
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
        public string ALF_SERI { get; set; }
        public string ALF_SUCU { get; set; }
        public int NUM_CORR { get; set; }
        public DateTime? FEC_ENTR { get; set; }
        public string ALF_CODI_ARTI { get; set; }
		public string ALF_ARTI { get; set; }
        public int NUM_CANT { get; set; }
        public decimal NUM_PREC_UNIT { get; set; }
        public decimal NUM_IMPO { get; set; }

        public string ALF_NUME_IDEN { get; set; }
        public DateTime? FEC_DESD { get; set; }
        public DateTime? FEC_HAST { get; set; }

        public List<BESVTD_COTI> LST_COTI { get; set; }
        public List<BESVTD_COTI> LST_COTI_DETA { get; set; }
        public List<BESVTD_COTI_GROU> LST_COTI_GROU { get; set; }
        public List<BESVTD_COTI> LST_COTI_ARTI_GROU { get; set; }
        public List<BESVTC_COTI> LST_GREM { get; set; }
        public List<BESVTC_COTI> LST_DVEN { get; set; }

        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_MODI { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int COD_TIPO_DOCU { get; set; }
        public int NUM_DIAS { get; set; }
        public int NUM_ACCI { get; set; }

        public string ALF_FECH_LARG { get; set; }
        public string ALF_EJEC_COME { get; set; }
        public string ALF_ATEN { get; set; }
        public string ALF_NOMB_GROU { get; set; }
        public DateTime? FEC_COTI { get; set; }
        public DateTime? FEC_OVEN { get; set; }
        public string ALF_MONE_SIMB { get; set; }
        public int COD_MOTI { get; set; }
        public string ALF_COND_COME { get; set; }
        public bool IND_FACT_NCRE { get; set; }
        public int COD_EJEC_COME { get; set; }
        public bool IND_IMPU { get; set; }
        public bool IND_LIQU { get; set; }
        public bool IND_ERRO { get; set; }
        public string ALF_ERRO { get; set; }
    }
}
