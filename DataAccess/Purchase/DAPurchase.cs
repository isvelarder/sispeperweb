using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities.Purchase;

namespace DataAccess.Purchase
{
    public class DAPurchase : IDisposable
    {
        private Database odb;
        private DbConnection ocn;
        public DAPurchase()
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
        ~DAPurchase()
        {
            Dispose(false);
        }
        //! ORDEN DE COMPRA
        /// <summary>
        /// Retorna las condiciones de pago según la compañia.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVMC_COND_PAGO(int COD_COMP)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVMC_COND_PAGO", COD_COMP);
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
        /// Retorna las monedas según la compañia.
        /// </summary>
        public IDataReader Get_PSGN_SPLS_SVMC_MONE(int COD_COMP)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVMC_MONE", COD_COMP);
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
        /// Retorna el tipo de cambio actual.
        /// <param name="IND_OPER">
        /// 1-VENTAS, 
        /// 2-COMPRAS
        /// </param>
        /// </summary>
        public decimal Get_PSGN_SPLS_SVMC_TIPO_CAMB(int COD_COMP, int IND_OPER)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSGN_SPLS_SVMC_TIPO_CAMB", COD_COMP, IND_OPER);
                ocmd.CommandTimeout = 2000;
                var osl = (decimal)odb.ExecuteScalar(ocmd);
                Dispose(false);
                return (osl);
            }
            finally
            {
                ocn.Close();
            }
        }
        /// <summary>
        /// Retorna el número de orden de compra siguiente.
        /// </summary>
        public string Get_PSCP_SPLS_ORCO_NURE(int COD_COMP)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_ORCO_NURE", COD_COMP);
                ocmd.CommandTimeout = 2000;
                var osl = odb.ExecuteScalar(ocmd).ToString();
                Dispose(false);
                return (osl);
            }
            finally
            {
                ocn.Close();
            }
        }
        /// <summary>
        /// Mantenimiento de Ordenes de compra.
        /// Inserta, Modifica
        /// </summary>
        public void Set_PSCP_SPMT_SCPC_ORCO(BEDocument odoc, List<BEDocumentLines> lines)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSCP_SPMT_SCPC_ORCO", odoc.COD_ORCO,
                                                                                      odoc.ALF_DOCU_REFE,
                                                                                      odoc.IND_ESTA,
                                                                                      odoc.COD_SUCU,
                                                                                      odoc.IND_TIPO_COMP,
                                                                                      odoc.COD_SOCI_NEGO,
                                                                                      odoc.ALF_SOCI_NEGO,
                                                                                      odoc.ALF_NUM_RUCC,
                                                                                      odoc.ALF_CONT,
                                                                                      odoc.ALF_DIRE_FISC,
                                                                                      odoc.ALF_DIRE_ENTR,
                                                                                      odoc.COD_MONE,
                                                                                      odoc.NUM_TIPO_CAMB,
                                                                                      odoc.COD_COND_PAGO,
                                                                                      odoc.COD_ALMA,
                                                                                      odoc.FEC_REGI,
                                                                                      odoc.FEC_ENTR,
                                                                                      odoc.FEC_DOCU,
                                                                                      odoc.FEC_PAGO,
                                                                                      odoc.ALF_COME,
                                                                                      odoc.NUM_SUBB_TOTA,
                                                                                      odoc.NUM_DESC,
                                                                                      odoc.NUM_IGVV,
                                                                                      odoc.NUM_ISCC,
                                                                                      odoc.NUM_TOTA,
                                                                                      odoc.COD_USUA_CREA,
                                                                                      odoc.COD_USUA_MODI,
                                                                                      odoc.IND_MNTN))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        odoc.COD_ORCO = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_ORCO"));

                        DbCommand cmdo;
                        var index = 1;
                        lines.ForEach(line =>
                        {
                            line.COD_ORCO = odoc.COD_ORCO;
                            line.NUM_LINE = index;
                            cmdo = odb.GetStoredProcCommand("PSCP_SPMT_SCPD_ORCO", line.COD_ORCO,
                                                                                   line.NUM_LINE,
                                                                                   line.COD_ARTI,
                                                                                   line.ALF_ARTI,
                                                                                   line.NUM_CANT,
                                                                                   line.NUM_PREC_UNIT_ORIG,
                                                                                   line.NUM_PREC_UNIT,
                                                                                   line.NUM_PORC_DESC,
                                                                                   line.NUM_DESC,
                                                                                   line.NUM_PREC_DESC,
                                                                                   line.NUM_IMPO,
                                                                                   odoc.COD_USUA_MODI);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                            index += 1;
                        });

                        var cmd1 = odb.GetStoredProcCommand("SVPR_ACTU_COMP", odoc.COD_USUA_CREA, odoc.COD_ALMA);
                        cmd1.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(cmd1, obts);                        

                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    odoc.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
        /// <summary>
        /// Retorna las ordenes de compra según filtro.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SCPC_ORCO(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SCPC_ORCO", obj.ALF_SOCI_NEGO, 
                                                                           obj.ALF_DOCU_REFE, 
                                                                           obj.FEC_REGI_INIC,
                                                                           obj.FEC_REGI_FINA,
                                                                           obj.IND_ESTA,
                                                                           obj.COD_SUCU);
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
        /// Retorna el detalle según la orden de compra seleccionada.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SCPD_ORCO(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SCPD_ORCO", obj.COD_ORCO);
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
        //! GUIA DE COMPRA
        /// <summary>
        /// Mantenimiento de guias de compra.
        /// Inserta, Modifica
        /// </summary>
        public void Set_PSCP_SPMT_SCPC_GUIA(BEDocument odoc, List<BEDocumentLines> lines, List<BEDocumentExpenses> expenses)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSCP_SPMT_SCPC_GUIA", odoc.COD_DOCU,
                                                                                      odoc.ALF_NUM_SERI,
                                                                                      odoc.ALF_NUM_CORR,
                                                                                      odoc.IND_ESTA,
                                                                                      odoc.COD_SUCU,
                                                                                      odoc.IND_TIPO_COMP,
                                                                                      odoc.COD_SOCI_NEGO,
                                                                                      odoc.ALF_SOCI_NEGO,
                                                                                      odoc.ALF_NUM_RUCC,
                                                                                      odoc.ALF_CONT,
                                                                                      odoc.ALF_DIRE_FISC,
                                                                                      odoc.ALF_DIRE_ENTR,
                                                                                      odoc.COD_MONE,
                                                                                      odoc.NUM_TIPO_CAMB,
                                                                                      odoc.COD_COND_PAGO,
                                                                                      odoc.COD_ALMA,
                                                                                      odoc.FEC_REGI,
                                                                                      odoc.FEC_ENTR,
                                                                                      odoc.FEC_DOCU,
                                                                                      odoc.FEC_PAGO,
                                                                                      odoc.ALF_COME,
                                                                                      odoc.NUM_SUBB_TOTA,
                                                                                      odoc.NUM_DESC,
                                                                                      odoc.NUM_IGVV,
                                                                                      odoc.NUM_ISCC,
                                                                                      odoc.NUM_TOTA,
                                                                                      odoc.COD_USUA_CREA,
                                                                                      odoc.COD_USUA_MODI,
                                                                                      odoc.IND_MNTN))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        odoc.COD_DOCU = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_DOCU"));

                        DbCommand cmdo;
                        var index = 1;
                        lines.ForEach(line =>
                        {
                            line.COD_DOCU = odoc.COD_DOCU;
                            line.NUM_LINE = index;
                            cmdo = odb.GetStoredProcCommand("PSCP_SPMT_SCPD_GUIA", line.COD_DOCU,
                                                                                   line.TIP_DOCU_BASE,
                                                                                   line.COD_DOCU_BASE,
                                                                                   line.NUM_LINE_BASE,
                                                                                   line.COD_ARTI_BASE,
                                                                                   line.NUM_LINE,
                                                                                   line.COD_ARTI,
                                                                                   line.ALF_ARTI,
                                                                                   line.NUM_CANT,
                                                                                   line.NUM_CANT_ABIE,
                                                                                   line.NUM_CANT_PERD,
                                                                                   line.NUM_PREC_UNIT_ORIG,
                                                                                   line.NUM_PREC_UNIT,
                                                                                   line.NUM_PORC_DESC,
                                                                                   line.NUM_DESC,
                                                                                   line.NUM_PREC_DESC,
                                                                                   line.NUM_IMPO,
                                                                                   odoc.COD_USUA_MODI);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                            index += 1;
                        });

                        expenses.ForEach(expe =>
                        {
                            expe.COD_DOCU = Convert.ToInt32(odoc.COD_DOCU);
                            cmdo = odb.GetStoredProcCommand("PSCP_SPMT_SCPC_GANA", expe.COD_GANA,                                                                                   
                                                                                   expe.COD_DOCU,
                                                                                   expe.NUM_DOCU,
                                                                                   expe.FEC_DOCU,
                                                                                   expe.COD_CONC_GANA,
                                                                                   expe.COD_SOCI_NEGO,
                                                                                   expe.ALF_NOMB_PROV,
                                                                                   expe.ALF_RUCC_PROV,
                                                                                   expe.COD_MONE,
                                                                                   expe.NUM_MONT,
                                                                                   odoc.COD_USUA_CREA);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                        });

                        var cmd1 = odb.GetStoredProcCommand("SVPR_ACTU_COMP", odoc.COD_USUA_CREA, odoc.COD_ALMA);
                        cmd1.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(cmd1, obts);  

                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    odoc.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
        /// <summary>
        /// Retorna las guías de compra según filtro.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SCPC_GUIA(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SCPC_GUIA", obj.ALF_SOCI_NEGO,
                                                                           obj.ALF_DOCU_REFE,
                                                                           obj.FEC_REGI_INIC,
                                                                           obj.FEC_REGI_FINA,
                                                                           obj.IND_ESTA,
                                                                           obj.COD_SUCU);
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
        /// Retorna el detalle según la guía de compra seleccionada.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SCPD_GUIA(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SCPD_GUIA", obj.COD_DOCU);
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
        /// Retorna los gastos de nacionalización según la guía de compra seleccionada.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SCPC_GANA(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SCPC_GANA", obj.COD_DOCU);
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
        //! FACTURA DE COMPRA
        /// <summary>
        /// Mantenimiento de facturas de compra.
        /// Inserta, Modifica
        /// </summary>
        public void Set_PSCP_SPMT_SCPC_OINV(BEDocument odoc, List<BEDocumentLines> lines)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSCP_SPMT_SCPC_OINV", odoc.COD_DOCU,
                                                                                      odoc.ALF_NUM_SERI,
                                                                                      odoc.ALF_NUM_CORR,
                                                                                      odoc.IND_ESTA,
                                                                                      odoc.COD_SUCU,
                                                                                      odoc.IND_TIPO_COMP,
                                                                                      odoc.COD_SOCI_NEGO,
                                                                                      odoc.ALF_SOCI_NEGO,
                                                                                      odoc.ALF_NUM_RUCC,
                                                                                      odoc.ALF_CONT,
                                                                                      odoc.ALF_DIRE_FISC,
                                                                                      odoc.ALF_DIRE_ENTR,
                                                                                      odoc.COD_MONE,
                                                                                      odoc.NUM_TIPO_CAMB,
                                                                                      odoc.COD_COND_PAGO,
                                                                                      odoc.COD_ALMA,
                                                                                      odoc.FEC_REGI,
                                                                                      odoc.FEC_ENTR,
                                                                                      odoc.FEC_DOCU,
                                                                                      odoc.FEC_PAGO,
                                                                                      odoc.ALF_COME,
                                                                                      odoc.NUM_SUBB_TOTA,
                                                                                      odoc.NUM_DESC,
                                                                                      odoc.NUM_IGVV,
                                                                                      odoc.NUM_ISCC,
                                                                                      odoc.NUM_TOTA,
                                                                                      odoc.COD_USUA_CREA,
                                                                                      odoc.COD_USUA_MODI,
                                                                                      odoc.IND_MNTN))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        odoc.COD_DOCU = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_DOCU"));

                        DbCommand cmdo;
                        var index = 1;
                        lines.ForEach(line =>
                        {
                            line.COD_DOCU = odoc.COD_DOCU;
                            line.NUM_LINE = index;
                            cmdo = odb.GetStoredProcCommand("PSCP_SPMT_SCPD_OINV", line.COD_DOCU,
                                                                                   line.TIP_DOCU_BASE,
                                                                                   line.COD_DOCU_BASE,
                                                                                   line.NUM_LINE_BASE,
                                                                                   line.COD_ARTI_BASE,
                                                                                   line.NUM_LINE,
                                                                                   line.COD_ARTI,
                                                                                   line.ALF_ARTI,
                                                                                   line.NUM_CANT,
                                                                                   line.NUM_CANT_ABIE,
                                                                                   line.NUM_PREC_UNIT_ORIG,
                                                                                   line.NUM_PREC_UNIT,
                                                                                   line.NUM_PORC_DESC,
                                                                                   line.NUM_DESC,
                                                                                   line.NUM_PREC_DESC,
                                                                                   line.NUM_IMPO,
                                                                                   odoc.COD_USUA_MODI);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                            index += 1;
                        });

                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    odoc.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
        /// <summary>
        /// Retorna las facturas de compra según filtro.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SCPC_OINV(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SCPC_OINV", obj.ALF_SOCI_NEGO,
                                                                           obj.ALF_DOCU_REFE,
                                                                           obj.FEC_REGI,
                                                                           obj.IND_ESTA,
                                                                           obj.COD_SUCU);
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
        /// Retorna el detalle según la factura de compra seleccionada.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SCPD_OINV(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SCPD_OINV", obj.COD_DOCU);
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
        //! NOTA DE CREDITO PROVEEDOR
        /// <summary>
        /// Mantenimiento de nota de crédito proveedor.
        /// Inserta, Modifica
        /// </summary>
        public void Set_PSCP_SPMT_SCPC_ORPC(BEDocument odoc, List<BEDocumentLines> lines)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("PSCP_SPMT_SCPC_ORPC", odoc.COD_DOCU,
                                                                                      odoc.ALF_NUM_SERI,
                                                                                      odoc.ALF_NUM_CORR,
                                                                                      odoc.IND_ESTA,
                                                                                      odoc.COD_SUCU,
                                                                                      odoc.IND_TIPO_COMP,
                                                                                      odoc.COD_SOCI_NEGO,
                                                                                      odoc.ALF_SOCI_NEGO,
                                                                                      odoc.ALF_NUM_RUCC,
                                                                                      odoc.ALF_CONT,
                                                                                      odoc.ALF_DIRE_FISC,
                                                                                      odoc.ALF_DIRE_ENTR,
                                                                                      odoc.COD_MONE,
                                                                                      odoc.NUM_TIPO_CAMB,
                                                                                      odoc.COD_COND_PAGO,
                                                                                      odoc.COD_ALMA,
                                                                                      odoc.FEC_REGI,
                                                                                      odoc.FEC_ENTR,
                                                                                      odoc.FEC_DOCU,
                                                                                      odoc.FEC_PAGO,
                                                                                      odoc.ALF_COME,
                                                                                      odoc.NUM_SUBB_TOTA,
                                                                                      odoc.NUM_DESC,
                                                                                      odoc.NUM_IGVV,
                                                                                      odoc.NUM_ISCC,
                                                                                      odoc.NUM_TOTA,
                                                                                      odoc.COD_USUA_CREA,
                                                                                      odoc.COD_USUA_MODI,
                                                                                      odoc.IND_MNTN))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        odoc.COD_DOCU = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_DOCU"));

                        DbCommand cmdo;
                        var index = 1;
                        lines.ForEach(line =>
                        {
                            line.COD_DOCU = odoc.COD_DOCU;
                            line.NUM_LINE = index;
                            cmdo = odb.GetStoredProcCommand("PSCP_SPMT_SCPD_ORPC", line.COD_DOCU,
                                                                                   line.TIP_DOCU_BASE,
                                                                                   line.COD_DOCU_BASE,
                                                                                   line.NUM_LINE_BASE,
                                                                                   line.COD_ARTI_BASE,
                                                                                   line.NUM_LINE,
                                                                                   line.COD_ARTI,
                                                                                   line.ALF_ARTI,
                                                                                   line.NUM_CANT,
                                                                                   line.NUM_CANT_ABIE,
                                                                                   line.NUM_PREC_UNIT_ORIG,
                                                                                   line.NUM_PREC_UNIT,
                                                                                   line.NUM_PORC_DESC,
                                                                                   line.NUM_DESC,
                                                                                   line.NUM_PREC_DESC,
                                                                                   line.NUM_IMPO,
                                                                                   odoc.COD_USUA_MODI);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                            index += 1;
                        });

                        obts.Commit();
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    odoc.MSG_MNTN = ex.Message;
                }
                finally
                {
                    ocn.Close();
                }
            }
        }
        /// <summary>
        /// Retorna las notas de crédito proveedor según filtro.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SCPC_ORPC(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SCPC_ORPC", obj.ALF_SOCI_NEGO,
                                                                           obj.ALF_DOCU_REFE,
                                                                           obj.FEC_REGI,
                                                                           obj.IND_ESTA,
                                                                           obj.COD_SUCU);
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
        /// Retorna el detalle según la nota de crédito proveedor seleccionada.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SCPD_ORPC(BEDocument obj)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SCPD_ORPC", obj.COD_DOCU);
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
        /// Retorna el detalle según la nota de crédito proveedor seleccionada.
        /// </summary>
        public IDataReader Get_PSCP_SPLS_SVMC_CNGN(int COD_COMP)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("PSCP_SPLS_SVMC_CNGN", COD_COMP);
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
