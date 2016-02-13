using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BRReceivingGoods : IDisposable
    {
        private DAReceivingGoods oda;
        public BRReceivingGoods()
        {
            oda = new DAReceivingGoods();
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
        ~BRReceivingGoods()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna las recepciónes de mercandería según el filtro.
        /// </summary>
        public List<BEReceivingGoods> Get_PSGN_SPLS_SVTC_ALMA_RECE(BEReceivingGoods obj)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTC_ALMA_RECE(obj))
            {
                var olst = new List<BEReceivingGoods>();
                ((IList)olst).LoadFromReader<BEReceivingGoods>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle de las recepciones de mercadería según el filtro.
        /// </summary>
        public List<BEReceivingGoodsDetail> Get_PSGN_SPLS_SVTD_ALMA_RECE(BEReceivingGoods obj)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTD_ALMA_RECE(obj))
            {
                var olst = new List<BEReceivingGoodsDetail>();
                ((IList)olst).LoadFromReader<BEReceivingGoodsDetail>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de recepciones de mercadería.
        /// Inserta
        /// </summary>
        public void Set_PSGN_SPMT_SVTC_ALMA_RECE(BEReceivingGoods obj, List<BEReceivingGoodsDetail> lsob)
        {
            oda.Set_PSGN_SPMT_SVTC_ALMA_RECE(obj, lsob);
            Dispose(false);
        }
    }
}
