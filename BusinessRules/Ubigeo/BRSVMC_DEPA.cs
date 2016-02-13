using BusinessEntities.Ubigeo;
using DataAccess.Ubigeo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultSetMappers;

namespace BusinessRules.Ubigeo
{
    public class BRSVMC_DEPA
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
        ~BRSVMC_DEPA()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_DEPA()
        {
            oDa = new DAUbigeo();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_DEPA> Get_SVPR_DEPA_LIST(BESVMC_DEPA oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_DEPA_LIST(oBe))
                {
                    List<BESVMC_DEPA> oList = new List<BESVMC_DEPA>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_DEPA>(oDr);
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
