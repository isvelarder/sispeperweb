using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BROutputGoods : IDisposable
    {
        private DAOutputGoods oda;
        public BROutputGoods()
        {
            oda = new DAOutputGoods();
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
        ~BROutputGoods()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna las salidas de mercandería según el filtro.
        /// </summary>
        public List<BEOutputGoods> Get_PSGN_SPLS_SVTC_ALMA_SALI(BEOutputGoods obog)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTC_ALMA_SALI(obog))
            {
                var olst = new List<BEOutputGoods>();
                ((IList)olst).LoadFromReader<BEOutputGoods>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle de las salidas de mercadería según el filtro.
        /// </summary>
        public List<BEOutputGoodsDetail> Get_PSGN_SPLS_SVTD_ALMA_SALI(BEOutputGoods obog)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTD_ALMA_SALI(obog))
            {
                var olst = new List<BEOutputGoodsDetail>();
                ((IList)olst).LoadFromReader<BEOutputGoodsDetail>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de salida de mercaderías.
        /// Inserta
        /// </summary>
        public void Set_PSGN_SPMT_SVTC_ALMA_SALI(BEOutputGoods obog, List<BEOutputGoodsDetail> lsog)
        {
            oda.Set_PSGN_SPMT_SVTC_ALMA_SALI(obog, lsog);
            Dispose(false);
        }
    }
}
