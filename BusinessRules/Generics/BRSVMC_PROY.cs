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
    public class BRSVMC_PROY : IDisposable
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
        ~BRSVMC_PROY()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_PROY()
        {
            oDa = new DAGenerics();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_PROY> Get_SVPR_PROY_LIST(BESVMC_PROY oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_PROY_LIST(oBe))
                {
                    List<BESVMC_PROY> oList = new List<BESVMC_PROY>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_PROY>(oDr);
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
        public void Set_SVPR_PROY(BESVMC_PROY oBe)
        {
            try
            {
                oDa.Set_SVPR_PROY(oBe);
                Dispose(false);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
