using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Purchase;
using BusinessEntities.Generics;
using DataAccess.Purchase;

namespace BusinessRules.Purchase
{
    public class BRPurchase : IDisposable
    {
        private DAPurchase oda;
        public BRPurchase()
        {
            oda = new DAPurchase();
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
        ~BRPurchase()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna las condiciones de pago según la compañia.
        /// </summary>
        public List<BESVMC_COND_PAGO> Get_PSGN_SPLS_SVMC_COND_PAGO(int COD_COMP)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_COND_PAGO(COD_COMP))
            {
                var olst = new List<BESVMC_COND_PAGO>();
                ((IList)olst).LoadFromReader<BESVMC_COND_PAGO>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna las monedas según la compañia.
        /// </summary>
        public List<BESVMC_MONE> Get_PSGN_SPLS_SVMC_MONE(int COD_COMP)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVMC_MONE(COD_COMP))
            {
                var olst = new List<BESVMC_MONE>();
                ((IList)olst).LoadFromReader<BESVMC_MONE>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el tipo de cambio actual.
        /// <param name="IND_OPER">
        /// 1-VENTAS, 
        /// 2-COMPRAS
        /// </param>
        /// </summary>
        public decimal Get_PSGN_SPLS_SVMC_TIPO_CAMB(int COD_COMP, int IND_OPER)
        {
            var TIPO_CAMB = oda.Get_PSGN_SPLS_SVMC_TIPO_CAMB(COD_COMP, IND_OPER);
            Dispose(false);
            return (TIPO_CAMB);
        }
        /// <summary>
        /// Retorna el número de orden de compra siguiente.
        /// </summary>
        public string Get_PSCP_SPLS_ORCO_NURE(int COD_COMP)
        {
            var ALF_REFE = oda.Get_PSCP_SPLS_ORCO_NURE(COD_COMP);
            Dispose(false);
            return (ALF_REFE);
        }
        /// <summary>
        /// Mantenimiento de Ordenes de compra.
        /// Inserta, Modifica
        /// </summary>
        public void Set_PSCP_SPMT_SCPC_ORCO(BEDocument odoc, List<BEDocumentLines> lines)
        {
            oda.Set_PSCP_SPMT_SCPC_ORCO(odoc, lines);
            Dispose(false);
        }
        /// <summary>
        /// Retorna las ordenes de compra según filtro.
        /// </summary>
        public List<BEDocument> Get_PSCP_SPLS_SCPC_ORCO(BEDocument obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SCPC_ORCO(obj))
            {
                var olst = new List<BEDocument>();
                ((IList)olst).LoadFromReader<BEDocument>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle según la orden de compra seleccionada.
        /// </summary>
        public List<BEDocumentLines> Get_PSCP_SPLS_SCPD_ORCO(BEDocument obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SCPD_ORCO(obj))
            {
                var olst = new List<BEDocumentLines>();
                ((IList)olst).LoadFromReader<BEDocumentLines>(odr);
                Dispose(false);
                return (olst);
            }
        }
        //! GUIA DE COMPRA
        /// <summary>
        /// Mantenimiento de guías de compra.
        /// Inserta, Modifica
        /// </summary>
        public void Set_PSCP_SPMT_SCPC_GUIA(BEDocument odoc, List<BEDocumentLines> lines, List<BEDocumentExpenses> expenses)
        {
            oda.Set_PSCP_SPMT_SCPC_GUIA(odoc, lines, expenses);
            Dispose(false);
        }
        /// <summary>
        /// Retorna las guías de compra según filtro.
        /// </summary>
        public List<BEDocument> Get_PSCP_SPLS_SCPC_GUIA(BEDocument obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SCPC_GUIA(obj))
            {
                var olst = new List<BEDocument>();
                ((IList)olst).LoadFromReader<BEDocument>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle según la guía de compra seleccionada.
        /// </summary>
        public List<BEDocumentLines> Get_PSCP_SPLS_SCPD_GUIA(BEDocument obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SCPD_GUIA(obj))
            {
                var olst = new List<BEDocumentLines>();
                ((IList)olst).LoadFromReader<BEDocumentLines>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna los gastos de nacionalización según la guía de compra seleccionada.
        /// </summary>
        public List<BEDocumentExpenses> Get_PSCP_SPLS_SCPC_GANA(BEDocument obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SCPC_GANA(obj))
            {
                var olst = new List<BEDocumentExpenses>();
                ((IList)olst).LoadFromReader<BEDocumentExpenses>(odr);
                Dispose(false);
                return (olst);
            }
        }
        //! FACTURA DE COMPRA
        /// <summary>
        /// Mantenimiento de facturas de compra.
        /// Inserta, Modifica
        /// </summary>
        public void Set_PSCP_SPMT_SCPC_OINV(BEDocument odoc, List<BEDocumentLines> lines)
        {
            oda.Set_PSCP_SPMT_SCPC_OINV(odoc, lines);
            Dispose(false);
        }
        /// <summary>
        /// Retorna las facturas de compra según filtro.
        /// </summary>
        public List<BEDocument> Get_PSCP_SPLS_SCPC_OINV(BEDocument obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SCPC_OINV(obj))
            {
                var olst = new List<BEDocument>();
                ((IList)olst).LoadFromReader<BEDocument>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle según la factura de compra seleccionada.
        /// </summary>
        public List<BEDocumentLines> Get_PSCP_SPLS_SCPD_OINV(BEDocument obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SCPD_OINV(obj))
            {
                var olst = new List<BEDocumentLines>();
                ((IList)olst).LoadFromReader<BEDocumentLines>(odr);
                Dispose(false);
                return (olst);
            }
        }
        //! NOTA DE CREDITO PROVEEDOR
        /// <summary>
        /// Mantenimiento de notas de crédito proveedor.
        /// Inserta, Modifica
        /// </summary>
        public void Set_PSCP_SPMT_SCPC_ORPC(BEDocument odoc, List<BEDocumentLines> lines)
        {
            oda.Set_PSCP_SPMT_SCPC_ORPC(odoc, lines);
            Dispose(false);
        }
        /// <summary>
        /// Retorna las notas de crédito de proveedor según filtro.
        /// </summary>
        public List<BEDocument> Get_PSCP_SPLS_SCPC_ORPC(BEDocument obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SCPC_ORPC(obj))
            {
                var olst = new List<BEDocument>();
                ((IList)olst).LoadFromReader<BEDocument>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle según la nota de crédito de proveedor seleccionada.
        /// </summary>
        public List<BEDocumentLines> Get_PSCP_SPLS_SCPD_ORPC(BEDocument obj)
        {
            using (var odr = oda.Get_PSCP_SPLS_SCPD_ORPC(obj))
            {
                var olst = new List<BEDocumentLines>();
                ((IList)olst).LoadFromReader<BEDocumentLines>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle según la nota de crédito proveedor seleccionada.
        /// </summary>
        public List<BEConceptsNationalization> Get_PSCP_SPLS_SVMC_CNGN(int COD_COMP)
        {
            using (var odr = oda.Get_PSCP_SPLS_SVMC_CNGN(COD_COMP))
            {
                var olst = new List<BEConceptsNationalization>();
                ((IList)olst).LoadFromReader<BEConceptsNationalization>(odr);
                Dispose(false);
                return (olst);
            }
        }
    }
}
