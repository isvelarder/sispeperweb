using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Security;
using DataAccess.Security;
using System.Data;
using System.Collections;
using ResultSetMappers;

namespace BusinessRules.Security
{
    public class BRSVMC_COMP : IDisposable
    {
        private DASecurity oDa;

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
        ~BRSVMC_COMP()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_COMP()
        {
            oDa = new DASecurity();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_COMP> Get_SVPR_COMP_LIST(BESVMC_COMP oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_COMP_LIST(oBe))
                {
                    List<BESVMC_COMP> oList = new List<BESVMC_COMP>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_COMP>(oDr);
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
        public void Set_SVPR_COMP(BESVMC_COMP oBe)
        {
            try
            {
                oDa.Set_SVPR_COMP(oBe);
                Dispose(false);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
