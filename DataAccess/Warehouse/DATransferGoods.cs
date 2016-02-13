using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Warehouse;

namespace DataAccess.Warehouse
{
    public class DATransferGoods : IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DATransferGoods()
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
        ~DATransferGoods()
        {
            Dispose(false);
        }
        /// <summary>
        /// Retorna las transferencias de mercadería según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTC_ALMA_TRAN(BETransferGoods obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTC_ALMA_TRAN", obj.COD_ALMA,
                                                                                obj.COD_MOTI,
                                                                                obj.FEC_TRAN,
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
        /// Retorna el detalle de las transferencias de mercadería según el filtro.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTD_ALMA_TRAN(BETransferGoods obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTD_ALMA_TRAN", obj.COD_ALMA_TRAN);
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
        /// Retorna las transferencias de mercadería para la recepción.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTC_ALMA_TRAN_RECE(BETransferGoods obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTC_ALMA_TRAN_RECE", obj.COD_ALMA,
                                                                                    obj.COD_MOTI,
                                                                                    obj.FEC_TRAN,
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
        /// Retorna el detalle de las transferencias de mercadería para la recepción.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVTD_ALMA_TRAN_RECE(BETransferGoods obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVTD_ALMA_TRAN_RECE", obj.COD_ALMA_TRAN);
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
        /// Mantenimiento de transferencia de mercaderías.
        /// Inserta
        /// </summary>
        public void Set_PSGN_SPMT_SVTC_ALMA_TRAN(BETransferGoods obj, List<BETransferGoodsDetail> lsob)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSGN_SPMT_SVTC_ALMA_TRAN", obj.COD_ALMA_TRAN,
                                                                                            obj.COD_ALMA,
                                                                                            obj.COD_SOCI_NEGO_RESP,
                                                                                            obj.COD_ALMA_DEST,
                                                                                            obj.COD_SOCI_NEGO_RESP_DEST,
                                                                                            obj.COD_MOTI,
                                                                                            obj.FEC_TRAN,
                                                                                            obj.FEC_REGI,
                                                                                            obj.ALF_COME,
                                                                                            obj.ALF_DOCU_REFE,
                                                                                            obj.COD_COMP,
                                                                                            obj.COD_USUA_CREA))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        obj.COD_ALMA_TRAN = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_ALMA_TRAN"));

                        DbCommand cmdo;
                        lsob.ForEach(item =>
                        {
                            item.COD_ALMA_TRAN = obj.COD_ALMA_TRAN;
                            cmdo = odb.GetStoredProcCommand("PSGN_SPMT_SVTD_ALMA_TRAN", item.COD_ALMA_TRAN_DETA,
                                                                                        item.COD_ALMA_TRAN,
                                                                                        item.COD_ARTI,
                                                                                        item.NUM_CANT,
                                                                                        item.NUM_CANT_MALO,
                                                                                        item.COD_USUA_CREA);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                            item.COD_ALMA_TRAN_DETA = Convert.ToInt32(odb.GetParameterValue(cmdo, "@COD_ALMA_TRAN_DETA"));
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
