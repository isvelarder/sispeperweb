using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BRTransferGoods : IDisposable
    {
        private DATransferGoods oda;
        public BRTransferGoods()
        {
            oda = new DATransferGoods();
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
        ~BRTransferGoods()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna las transferencias de mercandería según el filtro.
        /// </summary>
        public List<BETransferGoods> Get_PSGN_SPLS_SVTC_ALMA_TRAN(BETransferGoods obj)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTC_ALMA_TRAN(obj))
            {
                var olst = new List<BETransferGoods>();
                ((IList)olst).LoadFromReader<BETransferGoods>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle de las transferencias de mercadería según el filtro.
        /// </summary>
        public List<BETransferGoodsDetail> Get_PSGN_SPLS_SVTD_ALMA_TRAN(BETransferGoods obj)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTD_ALMA_TRAN(obj))
            {
                var olst = new List<BETransferGoodsDetail>();
                ((IList)olst).LoadFromReader<BETransferGoodsDetail>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna las transferencias de mercandería para la recepción.
        /// </summary>
        public List<BETransferGoods> Get_PSGN_SPLS_SVTC_ALMA_TRAN_RECE(BETransferGoods obj)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTC_ALMA_TRAN_RECE(obj))
            {
                var olst = new List<BETransferGoods>();
                ((IList)olst).LoadFromReader<BETransferGoods>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle de las transferencias de mercadería para la recepción.
        /// </summary>
        public List<BETransferGoodsDetail> Get_PSGN_SPLS_SVTD_ALMA_TRAN_RECE(BETransferGoods obj)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTD_ALMA_TRAN_RECE(obj))
            {
                var olst = new List<BETransferGoodsDetail>();
                ((IList)olst).LoadFromReader<BETransferGoodsDetail>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de transferencias de mercadería.
        /// Inserta
        /// </summary>
        public void Set_PSGN_SPMT_SVTC_ALMA_TRAN(BETransferGoods obj, List<BETransferGoodsDetail> lsob)
        {
            oda.Set_PSGN_SPMT_SVTC_ALMA_TRAN(obj, lsob);
            Dispose(false);
        }
    }
}
