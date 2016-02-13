using DataAccess.Ubigeo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultSetMappers;
using BusinessEntities.Ubigeo;

namespace BusinessRules.Ubigeo
{
    public class BRSVMC_PROV
    {
        private DAUbigeo oDa;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (oDa != null)
                {
                    oDa.Dispose();
                    oDa = null;
                }
        }
        ~BRSVMC_PROV()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_PROV()
        {
            oDa = new DAUbigeo();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_PROV> Get_SVPR_PROV_LIST(BESVMC_PROV oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_PROV_LIST(oBe))
                {
                    List<BESVMC_PROV> oList = new List<BESVMC_PROV>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_PROV>(oDr);
                    Dispose(false);
                    return (oList);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
