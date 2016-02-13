using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BRModelArticle : IDisposable
    {
        private DAModelArticle oda;
        public BRModelArticle()
        {
            oda = new DAModelArticle();
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
        ~BRModelArticle()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna todos los modelos de artículo.
        /// </summary>
        public List<BEModelArticle> Get_PSGN_SPLS_SVMC_MODE_ARTI(int COD_COMP)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_MODE_ARTI(COD_COMP))
            {
                var olst = new List<BEModelArticle>();
                ((IList)olst).LoadFromReader<BEModelArticle>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de modelos de artículo.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSGN_SPMT_SVMC_MODE_ARTI(BEModelArticle obej, List<BEModelArticle> olst)
        {
            oda.Set_PSGN_SPMT_SVMC_MODE_ARTI(obej, olst);
            Dispose(false);
        }
    }
}
