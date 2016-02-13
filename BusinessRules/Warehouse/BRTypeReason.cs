using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BRTypeReason : IDisposable
    {
        private DATypeReason oda;
        public BRTypeReason()
        {
            oda = new DATypeReason();
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
        ~BRTypeReason()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna todos los tipos de motivo.
        /// </summary>
        public List<BETypeReason> Get_PSGN_SPLS_SVMC_TIPO_MOTI()
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_TIPO_MOTI())
            {
                var olst = new List<BETypeReason>();
                ((IList)olst).LoadFromReader<BETypeReason>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de tipos de motivo.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSGN_SPMT_SVMC_TIPO_MOTI(BETypeReason obej, List<BETypeReason> olst)
        {
            oda.Set_PSGN_SPMT_SVMC_TIPO_MOTI(obej, olst);
            Dispose(false);
        }
    }
}
