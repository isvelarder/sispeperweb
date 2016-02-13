using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Report;

namespace DataAccess.Report
{
    public class DASales : IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DASales()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            odb = factory.Create("PS");
            ocn = odb.CreateConnection();
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
                ocn.Dispose();
                ((IDisposable)odb).Dispose();
                ocn = null;
                odb = null;
            }
            disposed = true;
        }
        ~DASales()
        {
            Dispose(false);
        }
        /// <summary>
        /// CON DATASET
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public DataSet SVPR_REPO_LIST(BEReport oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_REPO_LIST",
                                                                oBe.FEC_DESD,
                                                                oBe.FEC_HAST,
                                                                oBe.COD_COMP,
                                                                oBe.COD_SOCI_NEGO,
                                                                oBe.NUM_ACCI);
                ocmd.CommandTimeout = 2000;
                var odr = odb.ExecuteDataSet(ocmd);
                Dispose(false);
                return (odr);
            }
            finally
            {
                ocn.Close();
            }
        }
        public DataSet Get_PSCP_SPLS_SVTC_COTI(BEReport oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SVTC_COTI",
                                                                oBe.FEC_DESD,
                                                                oBe.FEC_HAST,
                                                                oBe.COD_COMP,
                                                                oBe.NUM_ACCI);
                ocmd.CommandTimeout = 2000;
                var odr = odb.ExecuteDataSet(ocmd);
                Dispose(false);
                return (odr);
            }
            finally
            {
                ocn.Close();
            }
        }
        public DataSet Get_PSCP_SPLS_SVTC_OVEN(BEReport oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SVTC_OVEN",
                                                                oBe.FEC_DESD,
                                                                oBe.FEC_HAST,
                                                                oBe.COD_COMP,
                                                                oBe.NUM_ACCI);
                ocmd.CommandTimeout = 2000;
                var odr = odb.ExecuteDataSet(ocmd);
                Dispose(false);
                return (odr);
            }
            finally
            {
                ocn.Close();
            }
        }
    }
}
