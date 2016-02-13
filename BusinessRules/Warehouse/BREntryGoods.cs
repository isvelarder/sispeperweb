using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Warehouse;
using DataAccess.Warehouse;

namespace BusinessRules.Warehouse
{
    public class BREntryGoods : IDisposable
    {
        private DAEntryGoods oda;
        public BREntryGoods()
        {
            oda = new DAEntryGoods();
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
        ~BREntryGoods()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna las entradas de mercandería según el filtro.
        /// </summary>
        public List<BEEntryGoods> Get_PSGN_SPLS_SVTC_ALMA_ENTR(BEEntryGoods obeg)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTC_ALMA_ENTR(obeg))
            {
                var olst = new List<BEEntryGoods>();
                ((IList)olst).LoadFromReader<BEEntryGoods>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Retorna el detalle de las entradas de mercadería según el filtro.
        /// </summary>
        public List<BEEntryGoodsDetail> Get_PSGN_SPLS_SVTD_ALMA_ENTR(BEEntryGoods obeg)
        {
            using (var odr = oda.Get_PSGN_SPLS_SVTD_ALMA_ENTR(obeg))
            {
                var olst = new List<BEEntryGoodsDetail>();
                ((IList)olst).LoadFromReader<BEEntryGoodsDetail>(odr);
                Dispose(false);
                return (olst);
            }
        }
        /// <summary>
        /// Mantenimiento de entrada de mercaderías.
        /// Inserta
        /// </summary>
        public void Set_PSGN_SPMT_SVTC_ALMA_ENTR(BEEntryGoods obeg, List<BEEntryGoodsDetail> lseg)
        {
            oda.Set_PSGN_SPMT_SVTC_ALMA_ENTR(obeg, lseg);
            Dispose(false);
        }
    }
}
