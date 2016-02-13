using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Warehouse;

namespace DataAccess.Warehouse
{
    public class DAReceivingGoods : IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DAReceivingGoods()
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
        ~DAReceivingGoods()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna las recepciones de mercadería según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTC_ALMA_RECE(BEReceivingGoods obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTC_ALMA_RECE", obj.COD_ALMA,
                                                                                obj.COD_MOTI,
                                                                                obj.FEC_RECE,
                                                                                obj.FEC_REGI,
                                                                                obj.ALF_DOCU_REFE,
                                                                                obj.COD_COMP);
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
        /// Retorna el detalle de las recepciones de mercadería según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTD_ALMA_RECE(BEReceivingGoods obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTD_ALMA_RECE", obj.COD_ALMA_RECE);
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
        /// Mantenimiento de recepción de mercaderías.
        /// Inserta
        /// </summary>
        public void Set_PSGN_SPMT_SVTC_ALMA_RECE(BEReceivingGoods obj, List<BEReceivingGoodsDetail> lsob)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSGN_SPMT_SVTC_ALMA_RECE", obj.COD_ALMA_RECE,
                                                                                           obj.COD_ALMA_TRAN,
                                                                                            obj.COD_ALMA,
                                                                                            obj.COD_SOCI_NEGO_RESP,
                                                                                            obj.COD_MOTI,
                                                                                            obj.FEC_RECE,
                                                                                            obj.FEC_REGI,
                                                                                            obj.ALF_COME,
                                                                                            obj.ALF_DOCU_REFE,
                                                                                            obj.COD_COMP,
                                                                                            obj.COD_USUA_CREA))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        obj.COD_ALMA_RECE = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_ALMA_RECE"));

                        DbCommand cmdo;
                        lsob.ForEach(item =>
                        {
                            item.COD_ALMA_RECE = obj.COD_ALMA_RECE;
                            cmdo = odb.GetStoredProcCommand("PSGN_SPMT_SVTD_ALMA_RECE", item.COD_ALMA_RECE_DETA,
                                                                                        item.COD_ALMA_RECE,
                                                                                        item.COD_ALMA_TRAN,
                                                                                        item.COD_ARTI,
                                                                                        item.NUM_CANT,
                                                                                        item.NUM_CANT_MALO,
                                                                                        item.COD_USUA_CREA);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                            item.COD_ALMA_RECE_DETA = Convert.ToInt32(odb.GetParameterValue(cmdo, "@COD_ALMA_RECE_DETA"));
                        });

                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    obj.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
    }
}
