using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Purchase;

namespace DataAccess.Report
{
    public class DAReportPurchase: IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DAReportPurchase()
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
        ~DAReportPurchase()
        {
            Dispose(false);
        }
        /// <summary>
        /// Reporte Registro de Compras Locales.
        /// </summary>
        public IDataReader Get_PPRP_SPLS_COM1(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PPRP_SPLS_COM1", obj.FEC_REGI_INIC, obj.FEC_REGI_FINA, obj.COD_SUCU);
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
        /// Reporte Registro de Compras Importadas.
        /// </summary>
        public IDataReader Get_PPRP_SPLS_COM2(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PPRP_SPLS_COM2", obj.FEC_REGI_INIC, obj.FEC_REGI_FINA, obj.COD_SUCU);
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
        /// Reporte Artículos por Compra.
        /// </summary>
        public IDataReader Get_PPRP_SPLS_COM3(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PPRP_SPLS_COM3", obj.FEC_REGI_INIC, obj.FEC_REGI_FINA, obj.COD_SUCU);
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
        /// Reporte de compras generadas.
        /// </summary>
        public IDataReader Get_PPRP_SPLS_COM4(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PPRP_SPLS_COM4", obj.FEC_REGI_INIC, obj.FEC_REGI_FINA, obj.COD_SUCU);
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
