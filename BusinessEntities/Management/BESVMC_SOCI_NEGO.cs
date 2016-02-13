using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Management
{
    public class BESVMC_SOCI_NEGO
    {
        public int COD_SOCI_NEGO { get; set; }
        public int COD_COMP { get; set; }
        public int COD_TIPO_SOCI { get; set; }
        public string ALF_TIPO_SOCI { get; set; }
        public string ALF_NOMB { get; set; }
        public int COD_TIPO_IDEN { get; set; }
        public string ALF_NUME_IDEN { get; set; }
        public int? COD_EJEC_COME { get; set; }
        public string ALF_DIRE_FISC { get; set; }
        public int? COD_PAIS_DIRE_FISC { get; set; }
        public string COD_DEPA_DIRE_FISC { get; set; }
        public string COD_PROV_DIRE_FISC { get; set; }
        public string COD_DIST_DIRE_FISC { get; set; }
        public string ALF_DIRE_RECE_FACT { get; set; }
        public int? COD_PAIS_DIRE_FACT { get; set; }
        public string COD_DEPA_RECE_FACT { get; set; }
        public string COD_PROV_RECE_FACT { get; set; }
        public string COD_DIST_RECE_FACT { get; set; }
        public int? COD_COND_PAGO { get; set; }
        public string ALF_TELE { get; set; }
        public string ALF_FAXX { get; set; }
        public string ALF_CONT { get; set; }
        public List<BESVMD_SOCI_NEGO_CONT> LST_CONT { get; set; }
        public List<BESVMD_SOCI_NEGO_SUCU> LST_SUCU { get; set; }

        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }

        public int NUM_ACCI { get; set; }

        public BESVMC_SOCI_NEGO()
        {
            LST_CONT = new List<BESVMD_SOCI_NEGO_CONT>();
            LST_SUCU = new List<BESVMD_SOCI_NEGO_SUCU>();
        }
    }
}
