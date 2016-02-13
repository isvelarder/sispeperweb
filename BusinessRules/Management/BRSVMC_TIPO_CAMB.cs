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
    public class BRSVMC_TIPO_CAMB : IDisposable
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
        ~BRSVMC_TIPO_CAMB()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_TIPO_CAMB()
        {
            oDa = new DAManagement();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_TIPO_CAMB> Get_SVPR_TIPO_CAMB_LIST(BESVMC_TIPO_CAMB oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_TIPO_CAMB_LIST(oBe))
                {
                    List<BESVMC_TIPO_CAMB> oList = new List<BESVMC_TIPO_CAMB>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_TIPO_CAMB>(oDr);
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
        public void Set_SVPR_TIPO_CAMB(BESVMC_TIPO_CAMB oBe)
        {
            try
            {
                oDa.Set_SVPR_TIPO_CAMB(oBe);
                Dispose(false);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
