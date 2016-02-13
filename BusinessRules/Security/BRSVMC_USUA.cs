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
    public class BRSVMC_USUA : IDisposable
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
        ~BRSVMC_USUA()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_USUA()
        {
            oDa = new DASecurity();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_USUA> Get_SVPR_USUA_LIST(BESVMC_USUA oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_USUA_LIST(oBe))
                {
                    List<BESVMC_USUA> oList = new List<BESVMC_USUA>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_USUA>(oDr);
                    Dispose(false);
                    return (oList);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        /// <summary>
        /// REALIZAR OPERACIONES DE MANTENIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        public void Set_SVPR_USUA(BESVMC_USUA oBe)
        {
            try
            {
                oDa.Set_SVPR_USUA(oBe);
                Dispose(false);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
