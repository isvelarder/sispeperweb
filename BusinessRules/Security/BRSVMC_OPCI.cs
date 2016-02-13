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
    public class BRSVMC_OPCI : IDisposable
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
        ~BRSVMC_OPCI()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_OPCI()
        {
            oDa = new DASecurity();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_OPCI> Get_SVPR_OPCI_LIST(BESVMC_OPCI oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_OPCI_LIST(oBe))
                {
                    List<BESVMC_OPCI> oList = new List<BESVMC_OPCI>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_OPCI>(oDr);
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
