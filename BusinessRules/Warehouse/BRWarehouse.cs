using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;
using System.Data;

namespace BusinessRules.Warehouse
{
    public class BRWarehouse : IDisposable
    {
        private DAWarehouse oda;
        public BRWarehouse()
        {
            oda = new DAWarehouse();
        }
        private bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                oda.Dispose();
                oda = null;
            }
            disposed = true;
        }
        ~BRWarehouse()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna todos los almacenes.
        /// </summary>
        public List<BEWarehouse> Get_PSGN_SPLS_SVMC_ALMA(int COD_COMP)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_ALMA(COD_COMP))
            {
                var olst = new List<BEWarehouse>();
                ((IList)olst).LoadFromReader<BEWarehouse>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna todos los encargados de almacén.
        /// </summary>
        public List<BEBusinessPartner> Get_PSGN_SPLS_SVMC_SOCI_NEGO(int COD_COMP)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_SOCI_NEGO(COD_COMP))
            {
                var olst = new List<BEBusinessPartner>();
                ((IList)olst).LoadFromReader<BEBusinessPartner>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de almacenes.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSGN_SPMT_SVMC_ALMA(BEWarehouse obej, List<BEWarehouse> olst)
        {
            oda.Set_PSGN_SPMT_SVMC_ALMA(obej, olst);
            Dispose(false);
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEWarehouse> Get_SVPR_ALMA_LIST(BEWarehouse oBe)
        {
            try
            {
                using (IDataReader oDr = oda.Get_SVPR_ALMA_LIST(oBe))
                {
                    List<BEWarehouse> oList = new List<BEWarehouse>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BEWarehouse>(oDr);
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
        public void Set_SVPR_ALMA(BEWarehouse oBe)
        {
            try
            {
                oda.Set_SVPR_ALMA(oBe);
                Dispose(false);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
