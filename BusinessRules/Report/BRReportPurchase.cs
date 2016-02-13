using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Purchase;
using DataAccess.Report;

namespace BusinessRules.Report
{
    public class BRReportPurchase : IDisposable
    {
        private DAReportPurchase oda;
        public BRReportPurchase()
        {
            oda = new DAReportPurchase();
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
        ~BRReportPurchase()
        {
            Dispose(false);
        }
        /// <summary>
        /// Reporte Registro de Compras Locales.
        /// </summary>
        public List<BEDocument> Get_PPRP_SPLS_COM1(BEDocument obj)
        {
            using (var odr = oda.Get_PPRP_SPLS_COM1(obj))
            {
                var olst = new List<BEDocument>();
                ((IList)olst).LoadFromReader<BEDocument>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Reporte Registro de Compras Importadas.
        /// </summary>
        public List<BEDocument> Get_PPRP_SPLS_COM2(BEDocument obj)
        {
            using (var odr = oda.Get_PPRP_SPLS_COM2(obj))
            {
                var olst = new List<BEDocument>();
                ((IList)olst).LoadFromReader<BEDocument>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Reporte Artículos por Compra.
        /// </summary>
        public List<BEDocument> Get_PPRP_SPLS_COM3(BEDocument obj)
        {
            using (var odr = oda.Get_PPRP_SPLS_COM3(obj))
            {
                var olst = new List<BEDocument>();
                ((IList)olst).LoadFromReader<BEDocument>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Reporte de compras generadas
        /// </summary>
        public List<BEDocument> Get_PPRP_SPLS_COM4(BEDocument obj)
        {
            using (var odr = oda.Get_PPRP_SPLS_COM4(obj))
            {
                var olst = new List<BEDocument>();
                ((IList)olst).LoadFromReader<BEDocument>(odr);
                Dispose(false);
                return (olst);
            }
        }
    }
}
