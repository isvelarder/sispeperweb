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
    public class BRSVTC_COTI : IDisposable
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
        ~BRSVTC_COTI()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVTC_COTI()
        {
            oDa = new DASales();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVTC_COTI> Get_SVPR_COTI_BUSC(BESVTC_COTI oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_COTI_BUSC(oBe))
                {
                    List<BESVTC_COTI> oList = new List<BESVTC_COTI>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVTC_COTI>(oDr);
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
        public void Set_SVPR_COTI(BESVTC_COTI oBe)
        {
            try
            {
                oDa.Set_SVPR_COTI(oBe);
                Dispose(false);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public List<BESVTC_COTI> SVPR_VALI_FACT_LIST(BESVTC_COTI oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.SVPR_VALI_FACT_LIST(oBe))
                {
                    List<BESVTC_COTI> oList = new List<BESVTC_COTI>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVTC_COTI>(oDr);
                    Dispose(false);
                    return (oList);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void Set_SVPR_DOCU_ESTA(BESVTC_COTI oBe)
        {
            try
            {
                oDa.Set_SVPR_DOCU_ESTA(oBe);
                Dispose(false);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
