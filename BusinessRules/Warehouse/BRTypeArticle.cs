using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BRTypeArticle : IDisposable
    {
        private DATypeArticle oda;
        public BRTypeArticle()
        {
            oda = new DATypeArticle();
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
        ~BRTypeArticle()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna todos los tipos de artículo.
        /// </summary>
        public List<BETypeArticle> Get_PSGN_SPLS_SVMC_TIPO_ARTI(int COD_COMP)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_TIPO_ARTI(COD_COMP))
            {
                var olst = new List<BETypeArticle>();
                ((IList)olst).LoadFromReader<BETypeArticle>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de tipos de artículo.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSGN_SPMT_SVMC_TIPO_ARTI(BETypeArticle obej, List<BETypeArticle> olst)
        {
            oda.Set_PSGN_SPMT_SVMC_TIPO_ARTI(obej, olst);
            Dispose(false);
        }
    }
}
