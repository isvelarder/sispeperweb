using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BRReason : IDisposable
    {
        private DAReason oda;
        public BRReason()
        {
            oda = new DAReason();
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
        ~BRReason()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna todos los motivos.
        /// </summary>
        public List<BEReason> Get_PSGN_SPLS_SVMC_MOTI(int COD_COMP)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_MOTI(COD_COMP))
            {
                var olst = new List<BEReason>();
                ((IList)olst).LoadFromReader<BEReason>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de motivos.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSGN_SPMT_SVMC_MOTI(BEReason obej, List<BEReason> olst)
        {
            oda.Set_PSGN_SPMT_SVMC_MOTI(obej, olst);
            Dispose(false);
        }
    }
}
