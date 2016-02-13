using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Security;
using DataAccess.Security;
using System.Data;
using System.Collections;
using ResultSetMappers;

namespace BusinessRules.Security
{
    public class BRSVMD_ACCE : IDisposable
    {
        private DASecurity oDa;

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
        ~BRSVMD_ACCE()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMD_ACCE()
        {
            oDa = new DASecurity();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMD_ACCE> Get_SVPR_ACCE_LIST(BESVMD_ACCE oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_ACCE_LIST(oBe))
                {
                    List<BESVMD_ACCE> oList = new List<BESVMD_ACCE>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMD_ACCE>(oDr);
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
