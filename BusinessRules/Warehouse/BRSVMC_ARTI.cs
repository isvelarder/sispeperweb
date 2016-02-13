using BusinessEntities.Generics;
using DataAccess.Generics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultSetMappers;
using DataAccess.Warehouse;
using BusinessEntities.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BRSVMC_ARTI : IDisposable
    {
        private DAWarehouse oDa;

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
        ~BRSVMC_ARTI()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_ARTI()
        {
            oDa = new DAWarehouse();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_ARTI> Get_SVPR_ARTI_LIST(BESVMC_ARTI oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_ARTI_LIST(oBe))
                {
                    List<BESVMC_ARTI> oList = new List<BESVMC_ARTI>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_ARTI>(oDr);
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
