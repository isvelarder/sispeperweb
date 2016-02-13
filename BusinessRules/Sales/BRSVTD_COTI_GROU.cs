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
using DataAccess.Sales;
using BusinessEntities.Sales;

namespace BusinessRules.Sales
{
    public class BRSVTD_COTI_GROU : IDisposable
    {
        private DASales oDa;

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
        ~BRSVTD_COTI_GROU()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVTD_COTI_GROU()
        {
            oDa = new DASales();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVTD_COTI_GROU> Get_SVPR_COTI_GROU_LIST(BESVTD_COTI_GROU oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_COTI_GROU_LIST(oBe))
                {
                    List<BESVTD_COTI_GROU> oList = new List<BESVTD_COTI_GROU>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVTD_COTI_GROU>(oDr);
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
