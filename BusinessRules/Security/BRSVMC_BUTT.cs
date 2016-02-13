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
    public class BRSVMC_BUTT : IDisposable
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
        ~BRSVMC_BUTT()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_BUTT()
        {
            oDa = new DASecurity();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_BUTT> Get_SVPR_BUTT_LIST(BESVMC_BUTT oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_BUTT_LIST(oBe))
                {
                    List<BESVMC_BUTT> oList = new List<BESVMC_BUTT>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_BUTT>(oDr);
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
