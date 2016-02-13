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
    public class BRSVMC_COND_PAGO : IDisposable
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
        ~BRSVMC_COND_PAGO()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_COND_PAGO()
        {
            oDa = new DAGenerics();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_COND_PAGO> Get_SVPR_COND_PAGO_LIST(BESVMC_COND_PAGO oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_COND_PAGO_LIST(oBe))
                {
                    List<BESVMC_COND_PAGO> oList = new List<BESVMC_COND_PAGO>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_COND_PAGO>(oDr);
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
        public void Set_SVPR_COND_PAGO(BESVMC_COND_PAGO oBe)
        {
            try
            {
                oDa.Set_SVPR_COND_PAGO(oBe);
                Dispose(false);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
