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
using DataAccess.Warehouse;
using BusinessEntities.Warehouse;
using DataAccess.Sales;
using BusinessEntities.Sales;

namespace BusinessRules.Sales
{
    public class BRSVTC_OVEN : IDisposable
    {
        private DASales oDa;

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
        ~BRSVTC_OVEN()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVTC_OVEN()
        {
            oDa = new DASales();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVTC_OVEN> Get_SVPR_OVEN_BUSC(BESVTC_OVEN oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_OVEN_BUSC(oBe))
                {
                    List<BESVTC_OVEN> oList = new List<BESVTC_OVEN>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVTC_OVEN>(oDr);
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
        public void Set_SVPR_OVEN(BESVTC_OVEN oBe)
        {
            try
            {
                oDa.Set_SVPR_OVEN(oBe);
                Dispose(false);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
