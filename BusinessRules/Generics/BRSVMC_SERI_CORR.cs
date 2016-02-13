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
using BusinessEntities.Sales;
using BusinessEntities.Warehouse;

namespace BusinessRules.Generics
{
    public class BRSVMC_SERI_CORR : IDisposable
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
        ~BRSVMC_SERI_CORR()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_SERI_CORR()
        {
            oDa = new DAGenerics();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_SERI_CORR> Get_SVPR_SERI_CORR_LIST(BESVMC_SERI_CORR oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_SERI_CORR_LIST(oBe))
                {
                    List<BESVMC_SERI_CORR> oList = new List<BESVMC_SERI_CORR>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_SERI_CORR>(oDr);
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
        public void Set_SVPR_SERI_CORR(BESVMC_SERI_CORR oBe)
        {
            try
            {
                oDa.Set_SVPR_SERI_CORR(oBe);
                Dispose(false);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
