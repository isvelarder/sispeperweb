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
    public class BRSVMD_SOCI_NEGO_CONT : IDisposable
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
        ~BRSVMD_SOCI_NEGO_CONT()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMD_SOCI_NEGO_CONT()
        {
            oDa = new DAManagement();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMD_SOCI_NEGO_CONT> Get_SVPR_SOCI_NEGO_CONT_LIST(BESVMD_SOCI_NEGO_CONT oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_SOCI_NEGO_CONT_LIST(oBe))
                {
                    List<BESVMD_SOCI_NEGO_CONT> oList = new List<BESVMD_SOCI_NEGO_CONT>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMD_SOCI_NEGO_CONT>(oDr);
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
