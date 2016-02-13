using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Warehouse;

namespace DataAccess.Warehouse
{
    public class DAModelArticle : IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DAModelArticle()
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
        ~DAModelArticle()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna todos los modelos de artículo.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVMC_MODE_ARTI(int COD_COMP)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVMC_MODE_ARTI", COD_COMP);
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
        /// Mantenimiento de modelos de artículo.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSGN_SPMT_SVMC_MODE_ARTI(BEModelArticle obej, List<BEModelArticle> olst)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    DbCommand ocmd;
                    olst.Where(item=>item.IND_MNTN != 0)
                        .ToList()
                        .ForEach(item =>
                    {
                        using (ocmd = odb.GetStoredProcCommand("PSGN_SPMT_SVMC_MODE_ARTI", item.COD_MODE_ARTI,
                                                                                           item.ALF_MODE_ARTI,
                                                                                           item.ALF_DESC,
                                                                                           item.COD_USUA_CREA,
                                                                                           item.COD_USUA_MODI,
                                                                                           item.IND_MNTN))
                        {
                            ocmd.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(ocmd, obts);
                            item.COD_MODE_ARTI = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_MODE_ARTI"));                            
                        }
                    });
                    obts.Commit();
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    obej.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
    }
}
