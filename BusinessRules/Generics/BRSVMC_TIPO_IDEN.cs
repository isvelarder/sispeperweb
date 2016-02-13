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
    public class BRSVMC_TIPO_IDEN : IDisposable
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
        ~BRSVMC_TIPO_IDEN()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_TIPO_IDEN()
        {
            oDa = new DAGenerics();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_TIPO_IDEN> Get_SVPR_TIPO_IDEN_LIST(BESVMC_TIPO_IDEN oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_TIPO_IDEN_LIST(oBe))
                {
                    List<BESVMC_TIPO_IDEN> oList = new List<BESVMC_TIPO_IDEN>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_TIPO_IDEN>(oDr);
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
        public void Set_SVPR_TIPO_IDEN(BESVMC_TIPO_IDEN oBe)
        {
            try
            {
                oDa.Set_SVPR_TIPO_IDEN(oBe);
                Dispose(false);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
