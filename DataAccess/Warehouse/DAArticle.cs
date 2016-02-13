using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Warehouse;

namespace DataAccess.Warehouse
{
    public class DAArticle : IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DAArticle()
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
        ~DAArticle()
        {
            Dispose(false);
        }
        /// <summary>
        /// Mantenimiento de Artículos.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSWH_SPMT_SVMC_ARTI(BEArticle obar)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSWH_SPMT_SVMC_ARTI", obar.COD_ARTI,
                                                                                      obar.COD_TIPO_ARTI,
                                                                                      obar.COD_MODE_ARTI,
                                                                                      obar.ALF_ARTI,
                                                                                      obar.ALF_CODI_ARTI,
                                                                                      obar.ALF_DESC,
                                                                                      obar.NUM_STOC_MINI,
                                                                                      obar.IMG_FOTO,
                                                                                      obar.COD_COMP,
                                                                                      obar.COD_USUA_CREA,
                                                                                      obar.COD_USUA_MODI,
                                                                                      obar.IND_MNTN))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        obar.COD_ARTI = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_ARTI"));
                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    obar.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
        /// <summary>
        /// Retorna los artículos según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVMC_ARTI(BEArticle opar)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVMC_ARTI", opar.ALF_CODI_ARTI, opar.ALF_ARTI, opar.COD_COMP);
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
        /// Retorna los artículos en almacén según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVMC_ARTI_ALMA(BEArticle opar)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVMC_ARTI_ALMA", opar.ALF_CODI_ARTI, opar.ALF_ARTI, opar.COD_ALMA, opar.COD_COMP);
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
        /// Retorna la lista de precios.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SVMC_LIST_PREC(int COD_COMP)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SVMC_LIST_PREC", COD_COMP);
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
        /// Retorna el detalle de la lista de precios.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SVMD_LIST_PREC(int COD_LIST_PREC)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SVMD_LIST_PREC", COD_LIST_PREC);
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
        /// Mantenimiento de lista de precios.
        /// Inserta, Modifica y Elimina
        /// </summary>
        public void Set_PSCP_SPMT_SVMC_LIST_PREC(BEPriceList obpc, List<BEPriceListDetail> olsp)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSCP_SPMT_SVMC_LIST_PREC", obpc.COD_LIST_PREC, 
                                                                                           obpc.ALF_LIST_PREC, 
                                                                                           obpc.IND_TIPO_LIST,
                                                                                           obpc.COD_COMP,
                                                                                           obpc.COD_USUA_CREA, 
                                                                                           obpc.COD_USUA_MODI,
                                                                                           obpc.IND_MNTN))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        obpc.COD_LIST_PREC = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_LIST_PREC"));

                        DbCommand cmdo;
                        olsp.ForEach(item =>
                        {
                            item.COD_LIST_PREC = obpc.COD_LIST_PREC;
                            cmdo = odb.GetStoredProcCommand("PSCP_SPMT_SVMD_LIST_PREC", item.COD_ARTI,
                                                                                        item.COD_LIST_PREC,
                                                                                        item.NUM_PREC,
                                                                                        item.NUM_DESC,
                                                                                        item.COD_USUA_CREA,
                                                                                        item.COD_USUA_MODI,
                                                                                        item.IND_MNTN);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                        });

                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    obpc.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
    }
}
