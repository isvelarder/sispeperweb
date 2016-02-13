using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Warehouse;

namespace DataAccess.Warehouse
{
    public class DAOutputGoods : IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DAOutputGoods()
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
        ~DAOutputGoods()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna las salidas de mercadería según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTC_ALMA_SALI(BEOutputGoods obog)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTC_ALMA_SALI", obog.COD_ALMA,
                                                                                obog.COD_MOTI,
                                                                                obog.FEC_SALI,
                                                                                obog.FEC_REGI,
                                                                                obog.ALF_DOCU_REFE,
                                                                                obog.COD_COMP);
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
        /// Retorna el detalle de las salidas de mercadería según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTD_ALMA_SALI(BEOutputGoods obog)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTD_ALMA_SALI", obog.COD_ALMA_SALI);
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
        /// Mantenimiento de salida de mercaderías.
        /// Inserta
        /// </summary>
        public void Set_PSGN_SPMT_SVTC_ALMA_SALI(BEOutputGoods obog, List<BEOutputGoodsDetail> lsog)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSGN_SPMT_SVTC_ALMA_SALI", obog.COD_ALMA_SALI,
                                                                                            obog.COD_ALMA,
                                                                                            obog.COD_SOCI_NEGO_RESP,
                                                                                            obog.COD_MOTI,
                                                                                            obog.FEC_SALI,
                                                                                            obog.FEC_REGI,
                                                                                            obog.ALF_COME,
                                                                                            obog.COD_COMP,
                                                                                            obog.ALF_DOCU_REFE,
                                                                                            obog.COD_USUA_CREA))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        obog.COD_ALMA_SALI = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_ALMA_SALI"));

                        DbCommand cmdo;
                        lsog.ForEach(item =>
                        {
                            item.COD_ALMA_SALI = obog.COD_ALMA_SALI;
                            cmdo = odb.GetStoredProcCommand("PSGN_SPMT_SVTD_ALMA_SALI", item.COD_SALI_DETA,
                                                                                        item.COD_ALMA_SALI,
                                                                                        item.COD_ARTI,
                                                                                        item.NUM_CANT,
                                                                                        item.NUM_CANT_MALO,
                                                                                        item.COD_USUA_CREA);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                            item.COD_SALI_DETA = Convert.ToInt32(odb.GetParameterValue(cmdo, "@COD_SALI_DETA"));
                        });

                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    obog.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
    }
}
