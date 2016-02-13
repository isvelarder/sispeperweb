using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Warehouse;

namespace DataAccess.Warehouse
{
    public class DAEntryGoods : IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DAEntryGoods()
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
        ~DAEntryGoods()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna las entradas de mercadería según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTC_ALMA_ENTR(BEEntryGoods obeg)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTC_ALMA_ENTR", obeg.COD_ALMA, 
                                                                                obeg.COD_MOTI, 
                                                                                obeg.FEC_ENTR, 
                                                                                obeg.FEC_REGI, 
                                                                                obeg.ALF_DOCU_REFE,
                                                                                obeg.COD_COMP);
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
        /// Retorna el detalle de las entradas de mercadería según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTD_ALMA_ENTR(BEEntryGoods obeg)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTD_ALMA_ENTR", obeg.COD_ALMA_ENTR);
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
        /// Mantenimiento de entrada de mercaderías.
        /// Inserta
        /// </summary>
        public void Set_PSGN_SPMT_SVTC_ALMA_ENTR(BEEntryGoods obeg, List<BEEntryGoodsDetail> lseg)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSGN_SPMT_SVTC_ALMA_ENTR", obeg.COD_ALMA_ENTR,
                                                                                            obeg.COD_ALMA,
                                                                                            obeg.COD_SOCI_NEGO_RESP,
                                                                                            obeg.COD_MOTI,
                                                                                            obeg.FEC_ENTR,
                                                                                            obeg.FEC_REGI,
                                                                                            obeg.ALF_COME,
                                                                                            obeg.COD_COMP,
                                                                                            obeg.ALF_DOCU_REFE,
                                                                                            obeg.COD_USUA_CREA))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        obeg.COD_ALMA_ENTR = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_ALMA_ENTR"));

                        DbCommand cmdo;
                        lseg.ForEach(item =>
                        {
                            item.COD_ALMA_ENTR = obeg.COD_ALMA_ENTR;
                            cmdo = odb.GetStoredProcCommand("PSGN_SPMT_SVTD_ALMA_ENTR", item.COD_ENTR_DETA,
                                                                                        item.COD_ALMA_ENTR,
                                                                                        item.COD_ARTI,
                                                                                        item.NUM_CANT,
                                                                                        item.NUM_CANT_MALO,
                                                                                        item.COD_USUA_CREA);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                            item.COD_ENTR_DETA = Convert.ToInt32(odb.GetParameterValue(cmdo, "@COD_ENTR_DETA"));
                        });

                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    obeg.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
    }
}
