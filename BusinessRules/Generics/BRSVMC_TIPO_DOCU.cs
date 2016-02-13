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
    public class BRSVMC_TIPO_DOCU : IDisposable
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
        ~BRSVMC_TIPO_DOCU()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_TIPO_DOCU()
        {
            oDa = new DAGenerics();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_TIPO_DOCU> Get_SVPR_TIPO_DOCU_LIST(BESVMC_TIPO_DOCU oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_TIPO_DOCU_LIST(oBe))
                {
                    List<BESVMC_TIPO_DOCU> oList = new List<BESVMC_TIPO_DOCU>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_TIPO_DOCU>(oDr);
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
        public void Set_SVPR_TIPO_DOCU(BESVMC_TIPO_DOCU oBe)
        {
            try
            {
                oDa.Set_SVPR_TIPO_DOCU(oBe);
                Dispose(false);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
