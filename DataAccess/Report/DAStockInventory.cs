using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Report;

namespace DataAccess.Report
{
    public class DAStockInventory : IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DAStockInventory()
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
        ~DAStockInventory()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna los stocks de los artículos.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVMD_ALMA_INVE(int COD_COMP)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVMD_ALMA_INVE", COD_COMP);
                ocmd.CommandTimeout = 2000;
                var odr = odb.ExecuteReader(ocmd);
                Dispose(false);
                return (odr);
            }
            finally
            {
                ocn.Close();
            }
        }
        /// <summary>
        /// Retorna los artículos del kardex.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SVMD_ALMA_KARD(BEKardexInventory obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SVMD_ALMA_KARD", obj.COD_ALMA, obj.FEC_OPER_INIC, obj.FEC_OPER_FINA, obj.COD_COMP);
                ocmd.CommandTimeout = 2000;
                var odr = odb.ExecuteReader(ocmd);
                Dispose(false);
                return (odr);
            }
            finally
            {
                ocn.Close();
            }
        }
        /// <summary>
        /// Retorna el stock valorizado.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SVMD_ALMA_INVE_VALO(BEStockValued obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SVMD_ALMA_INVE_VALO", obj.COD_COMP, obj.COD_ALMA);
                ocmd.CommandTimeout = 2000;
                var odr = odb.ExecuteReader(ocmd);
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
