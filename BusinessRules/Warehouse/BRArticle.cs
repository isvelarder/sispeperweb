using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BRArticle : IDisposable
    {
        private DAArticle oda;
        public BRArticle()
        {
            oda = new DAArticle();
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
        ~BRArticle()
        {
            Dispose(false);
        }
        /// <summary>
        /// Mantenimiento de Artículos.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSWH_SPMT_SVMC_ARTI(BEArticle obar)
        {
            oda.Set_PSWH_SPMT_SVMC_ARTI(obar);
            Dispose(false);
        }
        /// <summary>
        /// Retorna artículos según el filtro.
        /// </summary>
        public List<BEArticle> Get_PSGN_SPLS_SVMC_ARTI(BEArticle opar)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_ARTI(opar))
            {
                var olst = new List<BEArticle>();
                ((IList)olst).LoadFromReader<BEArticle>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna artículos en almacén según el filtro.
        /// </summary>
        public List<BEArticle> Get_PSGN_SPLS_SVMC_ARTI_ALMA(BEArticle opar)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_ARTI_ALMA(opar))
            {
                var olst = new List<BEArticle>();
                ((IList)olst).LoadFromReader<BEArticle>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna la lista de precios.
        /// </summary>
        public List<BEPriceList> Get_PSCP_SPLS_SVMC_LIST_PREC(int COD_COMP)
        {
            using (var odr = oda.Get_PSCP_SPLS_SVMC_LIST_PREC(COD_COMP))
            {
                var olst = new List<BEPriceList>();
                ((IList)olst).LoadFromReader<BEPriceList>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle de la lista de precios.
        /// </summary>
        public List<BEPriceListDetail> Get_PSCP_SPLS_SVMD_LIST_PREC(int COD_LIST_PREC)
        {
            using (var odr = oda.Get_PSCP_SPLS_SVMD_LIST_PREC(COD_LIST_PREC))
            {
                var olst = new List<BEPriceListDetail>();
                ((IList)olst).LoadFromReader<BEPriceListDetail>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de lista de precios.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSCP_SPMT_SVMC_LIST_PREC(BEPriceList obpc, List<BEPriceListDetail> olsp)
        {
            oda.Set_PSCP_SPMT_SVMC_LIST_PREC(obpc, olsp);
            Dispose(false);
        }
    }
}
