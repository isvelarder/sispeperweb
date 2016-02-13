using System;
using System.Collections.Generic;
using System.Linq;
using ResultSetMappers;
using System.Collections;
using BusinessEntities.Report;
using DataAccess.Report;
using System.Data;

namespace BusinessRules.Report
{
    public class BRSales : IDisposable
    {
        private DASales oda;
        public BRSales()
        {
            oda = new DASales();
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
        ~BRSales()
        {
            Dispose(false);
        }
        public DataTable SVPR_REPO_LIST(BEReport oBe)
        {
            using (var odr = oda.SVPR_REPO_LIST(oBe))
            {
                if (odr.Tables.Count == 0) return (new DataTable());
                var olst = odr.Tables[0];
                Dispose(false);
                return (olst);
            }
        }
        public DataTable Get_PSCP_SPLS_SVTC_COTI(BEReport oBe)
        {
            using (var odr = oda.Get_PSCP_SPLS_SVTC_COTI(oBe))
            {
                if (odr.Tables.Count == 0) return (new DataTable());
                var olst = odr.Tables[0];
                Dispose(false);
                return (olst);
            }
        }
        public DataTable Get_PSCP_SPLS_SVTC_OVEN(BEReport oBe)
        {
            using (var odr = oda.Get_PSCP_SPLS_SVTC_OVEN(oBe))
            {
                if (odr.Tables.Count == 0) return (new DataTable());
                var olst = odr.Tables[0];
                Dispose(false);
                return (olst);
            }
        }
    }
}
