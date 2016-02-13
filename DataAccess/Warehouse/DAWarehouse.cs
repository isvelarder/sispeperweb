using BusinessEntities.Generics;
using BusinessEntities.Sales;
using BusinessEntities.Warehouse;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Warehouse
{
    public class DAWarehouse : IDisposable
    {
        private Database odb;
        private DbConnection ocn;

        public DAWarehouse()
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

        ~DAWarehouse()
        {
            Dispose(false);
        }

        public IDataReader Get_SVPR_ARTI_LIST(BESVMC_ARTI oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_ARTI_BUSC",
                                                    oBe.ALF_CODI_ARTI,
                                                    oBe.ALF_ARTI,
                                                    oBe.COD_COMP, 
                                                    oBe.NUM_ACCI
                                                );
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
        /// Retorna todos los almacenes.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVMC_ALMA(int COD_COMP)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVMC_ALMA", COD_COMP);
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
        /// Retorna todos los encargados de almacén.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVMC_SOCI_NEGO(int COD_COMP)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVMC_SOCI_NEGO", COD_COMP);
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
        /// Mantenimiento de almacenes.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSGN_SPMT_SVMC_ALMA(BEWarehouse obej, List<BEWarehouse> olst)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    DbCommand ocmd;
                    olst.Where(item => item.IND_MNTN != 0)
                        .ToList()
                        .ForEach(item =>
                        {
                            using (ocmd = odb.GetStoredProcCommand("PSGN_SPMT_SVMC_ALMA", item.COD_ALMA,
                                                                                          item.ALF_ALMA,
                                                                                          item.ALF_DESC,
                                                                                          item.COD_SOCI_NEGO_ENCA,
                                                                                          item.COD_COMP,
                                                                                          item.COD_USUA_CREA,
                                                                                          item.COD_USUA_MODI,
                                                                                          item.IND_MNTN))
                            {
                                ocmd.CommandTimeout = 2000;
                                odb.ExecuteNonQuery(ocmd, obts);
                                item.COD_ALMA = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_ALMA"));
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
        public IDataReader Get_SVPR_ALMA_LIST(BEWarehouse oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_ALMA_LIST",
                                                                    oBe.COD_ALMA,
                                                                    oBe.COD_COMP,
                                                                    oBe.ALF_ALMA,
                                                                    oBe.ALF_DESC,
                                                                    oBe.COD_SOCI_NEGO_ENCA,
                                                                    oBe.COD_USUA_CREA,
                                                                    oBe.COD_USUA_MODI,
                                                                    oBe.NUM_ACCI
                                                );
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

        public void Set_SVPR_ALMA(BEWarehouse oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_ALMA", 
                                                                        oBe.COD_ALMA,
                                                                        oBe.COD_COMP,
                                                                        oBe.ALF_ALMA,
                                                                        oBe.ALF_DESC,
                                                                        oBe.COD_SOCI_NEGO_ENCA,
                                                                        oBe.COD_USUA_CREA,
                                                                        oBe.COD_USUA_MODI,
                                                                        oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_ALMA = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_ALMA"));
                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
    }
}
