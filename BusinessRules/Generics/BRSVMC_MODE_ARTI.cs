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

namespace BusinessRules.Generics
{
    public class BRSVMC_MODE_ARTI : IDisposable
    {
        private DAGenerics oDa;

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
        ~BRSVMC_MODE_ARTI()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_MODE_ARTI()
        {
            oDa = new DAGenerics();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_MODE_ARTI> Get_SVPR_MODE_ARTI_LIST(BESVMC_MODE_ARTI oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_MODE_ARTI_LIST(oBe))
                {
                    List<BESVMC_MODE_ARTI> oList = new List<BESVMC_MODE_ARTI>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_MODE_ARTI>(oDr);
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
        public void Set_SVPR_MODE_ARTI(BESVMC_MODE_ARTI oBe)
        {
            try
            {
                oDa.Set_SVPR_MODE_ARTI(oBe);
                Dispose(false);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
