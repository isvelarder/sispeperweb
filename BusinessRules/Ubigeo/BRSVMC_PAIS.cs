using BusinessEntities.Ubigeo;
using DataAccess.Ubigeo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultSetMappers;

namespace BusinessRules.Ubigeo
{
    public class BRSVMC_PAIS : IDisposable
    {
        private DAUbigeo oDa;

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
        ~BRSVMC_PAIS()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVMC_PAIS()
        {
            oDa = new DAUbigeo();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVMC_PAIS> Get_SVPR_PAIS_LIST(BESVMC_PAIS oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_PAIS_LIST(oBe))
                {
                    List<BESVMC_PAIS> oList = new List<BESVMC_PAIS>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVMC_PAIS>(oDr);
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
        public void Set_SVPR_PAIS(BESVMC_PAIS oBe)
        {
            try
            {
                oDa.Set_SVPR_PAIS(oBe);
                Dispose(false);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
