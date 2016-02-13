using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Report;
using DataAccess.Report;

namespace BusinessRules.Report
{
    public class BRStockInventory : IDisposable
    {
        private DAStockInventory oda;
        public BRStockInventory()
        {
            oda = new DAStockInventory();
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
        ~BRStockInventory()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna los stocks de los artículos.
        /// </summary>
        public List<BECloneStockInventoy> Get_PSGN_SPLS_SVMD_ALMA_INVE(int COD_COMP)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMD_ALMA_INVE(COD_COMP))
            {
                var olst = new List<BECloneStockInventoy>();
                ((IList)olst).LoadFromReader<BECloneStockInventoy>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna los artículos del kardex.
        /// </summary>
        public List<BEKardexInventory> Get_PSCP_SPLS_SVMD_ALMA_KARD(BEKardexInventory obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SVMD_ALMA_KARD(obj))
            {
                var olst = new List<BEKardexInventory>();
                ((IList)olst).LoadFromReader<BEKardexInventory>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        ///  Retorna el stock valorizado.
        /// </summary>
        public List<BEStockValued> Get_PSCP_SPLS_SVMD_ALMA_INVE_VALO(BEStockValued obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SVMD_ALMA_INVE_VALO(obj))
            {
                var olst = new List<BEStockValued>();
                ((IList)olst).LoadFromReader<BEStockValued>(odr);
                Dispose(false);
                return (olst);
            }
        }
    }
}
