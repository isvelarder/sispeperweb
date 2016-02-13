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
using DataAccess.Management;
using BusinessEntities.Management;

namespace BusinessRules.Management
{
    public class BRSVMC_SOCI_NEGO : IDisposable
    {
        private DAManagement oDa;

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
        ~BRSVMC_SOCI_NEGO()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_SOCI_NEGO()
        {
            oDa = new DAManagement();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_SOCI_NEGO> Get_SVPR_SOCI_NEGO_LIST(BESVMC_SOCI_NEGO oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_SOCI_NEGO_LIST(oBe))
                {
                    List<BESVMC_SOCI_NEGO> oList = new List<BESVMC_SOCI_NEGO>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_SOCI_NEGO>(oDr);
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
        public void Set_SVPR_SOCI_NEGO(BESVMC_SOCI_NEGO oBe)
        {
            try
            {
                oDa.Set_SVPR_SOCI_NEGO(oBe);
                Dispose(false);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
