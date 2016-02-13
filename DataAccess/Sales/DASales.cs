using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Security;
using BusinessEntities.Sales;
using BusinessEntities.Report;

namespace DataAccess.Sales
{
    public class DASales
    {
        private Database odb;
        private DbConnection ocn;

        public DASales()
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

        ~DASales()
        {
            Dispose(false);
        }

        public IDataReader Get_SVPR_COTI_BUSC(BESVTC_COTI oBe)
        {
            var ALF_NOMB_PROC = "";
            if (oBe.COD_TIPO_DOCU == 1)
                ALF_NOMB_PROC = "SVPR_COTI_BUSC";
            if (oBe.COD_TIPO_DOCU == 2)
                ALF_NOMB_PROC = "SVPR_OVEN_BUSC";
            if (oBe.COD_TIPO_DOCU == 3)
                ALF_NOMB_PROC = "SVPR_GREM_BUSC";
            if (oBe.COD_TIPO_DOCU == 4)
                ALF_NOMB_PROC = "SVPR_DVEN_BUSC";
            if (oBe.COD_TIPO_DOCU == 5)
                ALF_NOMB_PROC = "SVPR_NCRE_BUSC";
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand(ALF_NOMB_PROC,
                                                    oBe.ALF_NUME_IDEN,
                                                    oBe.COD_COMP,
                                                    oBe.COD_MONE,
                                                    oBe.FEC_DESD,
                                                    oBe.FEC_HAST,
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

        public IDataReader Get_SVPR_OVEN_BUSC(BESVTC_OVEN oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_OVEN_BUSC",
                                                    oBe.ALF_NUME_IDENT,
                                                    oBe.FEC_DESD,
                                                    oBe.FEC_HAST,
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

        public IDataReader Get_SVPR_COTI_DETA_LIST(BESVTD_COTI oBe)
        {
            var ALF_NOMB_PROC = "";
            if (oBe.COD_TIPO_DOCU == 1)
                ALF_NOMB_PROC = "SVPR_COTI_DETA_LIST";
            else if (oBe.COD_TIPO_DOCU == 2)
                ALF_NOMB_PROC = "SVPR_OVEN_DETA_LIST";
            else if (oBe.COD_TIPO_DOCU == 3)
                ALF_NOMB_PROC = "SVPR_GREM_DETA_LIST";
            else if (oBe.COD_TIPO_DOCU == 4)
                ALF_NOMB_PROC = "SVPR_DVEN_DETA_LIST";
            else if (oBe.COD_TIPO_DOCU == 5)
                ALF_NOMB_PROC = "SVPR_NCRE_DETA_LIST";

            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand(ALF_NOMB_PROC,
                                                                    oBe.COD_COTI,
                                                                    oBe.COD_ARTI,
                                                                    oBe.ALF_ARTI,
                                                                    oBe.NUM_PREC_UNIT,
                                                                    oBe.NUM_PORC_DESC,
                                                                    oBe.NUM_DESC,
                                                                    oBe.NUM_CANT,
                                                                    oBe.NUM_STOC_REAL,
                                                                    oBe.NUM_STOC_VIRT,
                                                                    oBe.NUM_IMPO,
                                                                    oBe.COD_USUA_CREA,
                                                                    oBe.COD_USUA_MODI,
                                                                    oBe.NUM_ACCI);
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

        public IDataReader Get_SVPR_OVEN_DETA_LIST(BESVTD_OVEN oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_OVEN_DETA_LIST",
                                                                    oBe.COD_OVEN,
                                                                    oBe.COD_ARTI,
                                                                    oBe.ALF_ARTI,
                                                                    oBe.NUM_PREC_UNIT,
                                                                    oBe.NUM_PORC_DESC,
                                                                    oBe.NUM_DESC,
                                                                    oBe.NUM_CANT,
                                                                    oBe.NUM_IMPO,
                                                                    oBe.COD_USUA_CREA,
                                                                    oBe.COD_USUA_MODI,
                                                                    oBe.NUM_ACCI);
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

        public IDataReader Get_SVPR_COTI_GROU_LIST(BESVTD_COTI_GROU oBe)
        {
            var ALF_NOMB_PROC = "";
            if (oBe.COD_TIPO_DOCU == 1)
                ALF_NOMB_PROC = "SVPR_COTI_GROU_LIST";
            else if (oBe.COD_TIPO_DOCU == 2)
                ALF_NOMB_PROC = "SVPR_OVEN_GROU_LIST";
            else if (oBe.COD_TIPO_DOCU == 3)
                ALF_NOMB_PROC = "SVPR_GREM_GROU_LIST";
            else if (oBe.COD_TIPO_DOCU == 4)
                ALF_NOMB_PROC = "SVPR_DVEN_GROU_LIST";

            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand(ALF_NOMB_PROC,
                                                    oBe.COD_COTI_GROU,
                                                    oBe.COD_COTI,
                                                    oBe.ALF_NOMB,
                                                    oBe.NUM_CANT,
                                                    oBe.COD_USUA_CREA,
                                                    oBe.COD_USUA_MODI,
                                                    oBe.NUM_ACCI);
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

        public IDataReader Get_SVPR_OVEN_GROU_LIST(BESVTD_OVEN_GROU oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_OVEN_GROU_LIST",
                                                                    oBe.COD_OVEN_GROU,
                                                                    oBe.COD_OVEN,
                                                                    oBe.ALF_NOMB,
                                                                    oBe.NUM_CANT,
                                                                    oBe.COD_USUA_CREA,
                                                                    oBe.COD_USUA_MODI,
                                                                    oBe.NUM_ACCI);
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

        public IDataReader Get_SVPR_COTI_GROU_DETA_LIST(BESVTD_COTI oBe)
        {
            var ALF_NOMB_PROC = "";
            if (oBe.COD_TIPO_DOCU == 1)
                ALF_NOMB_PROC = "SVPR_COTI_GROU_DETA_LIST";
            else if (oBe.COD_TIPO_DOCU == 2)
                ALF_NOMB_PROC = "SVPR_OVEN_GROU_DETA_LIST";
            else if (oBe.COD_TIPO_DOCU == 3)
                ALF_NOMB_PROC = "SVPR_GREM_GROU_DETA_LIST";
            else if (oBe.COD_TIPO_DOCU == 4)
                ALF_NOMB_PROC = "SVPR_DVEN_GROU_DETA_LIST";

            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand(ALF_NOMB_PROC,
                                                                    oBe.COD_COTI,
                                                                    oBe.COD_ARTI,
                                                                    oBe.ALF_ARTI,
                                                                    oBe.NUM_PREC_UNIT,
                                                                    oBe.NUM_PORC_DESC,
                                                                    oBe.NUM_DESC,
                                                                    oBe.NUM_CANT,
                                                                    oBe.NUM_IMPO,
                                                                    oBe.COD_USUA_CREA,
                                                                    oBe.COD_USUA_MODI,
                                                                    oBe.NUM_ACCI);
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

        public IDataReader Get_SVPR_OVEN_GROU_DETA_LIST(BESVTD_OVEN oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_OVEN_GROU_DETA_LIST",
                                                                    oBe.COD_OVEN,
                                                                    oBe.COD_ARTI,
                                                                    oBe.ALF_ARTI,
                                                                    oBe.NUM_PREC_UNIT,
                                                                    oBe.NUM_PORC_DESC,
                                                                    oBe.NUM_DESC,
                                                                    oBe.NUM_CANT,
                                                                    oBe.NUM_IMPO,
                                                                    oBe.COD_USUA_CREA,
                                                                    oBe.COD_USUA_MODI,
                                                                    oBe.NUM_ACCI);
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
        /// REALIZAR OPERACIONES DE MANTENIMIENTO PARA LA COTIZACION
        /// </summary>
        /// <param name="oBe"></param>
        public void Set_SVPR_COTI(BESVTC_COTI oBe)
        {
            var ALF_NOMB_PROC = "";
            var ALF_NOMB_PROC_DETA = "";
            var ALF_NOMB_PROC_GROU = "";
            var ALF_NOMB_PROC_GROU_DETA = "";
            var ALF_NOMB_PARA_SALI = "";

            if (oBe.COD_TIPO_DOCU == 1)
            {
                ALF_NOMB_PROC = "SVPR_COTI";
                ALF_NOMB_PROC_DETA = "SVPR_COTI_DETA";
                ALF_NOMB_PROC_GROU = "SVPR_COTI_GROU";
                ALF_NOMB_PROC_GROU_DETA = "SVPR_COTI_GROU_DETA";
                ALF_NOMB_PARA_SALI = "@COD_COTI";
            }
            else if (oBe.COD_TIPO_DOCU == 2)
            {
                ALF_NOMB_PROC = "SVPR_OVEN";
                ALF_NOMB_PROC_DETA = "SVPR_OVEN_DETA";
                ALF_NOMB_PROC_GROU = "SVPR_OVEN_GROU";
                ALF_NOMB_PROC_GROU_DETA = "SVPR_OVEN_GROU_DETA";
                ALF_NOMB_PARA_SALI = "@COD_OVEN";
            }
            else if (oBe.COD_TIPO_DOCU == 3)
            {
                ALF_NOMB_PROC = "SVPR_GREM";
                ALF_NOMB_PROC_DETA = "SVPR_GREM_DETA";
                ALF_NOMB_PROC_GROU = "SVPR_GREM_GROU";
                ALF_NOMB_PROC_GROU_DETA = "SVPR_GREM_GROU_DETA";
                ALF_NOMB_PARA_SALI = "@COD_GREM";
            }
            else if (oBe.COD_TIPO_DOCU == 4)
            {
                ALF_NOMB_PROC = "SVPR_DVEN";
                ALF_NOMB_PROC_DETA = "SVPR_DVEN_DETA";
                ALF_NOMB_PROC_GROU = "SVPR_DVEN_GROU";
                ALF_NOMB_PROC_GROU_DETA = "SVPR_DVEN_GROU_DETA";
                ALF_NOMB_PARA_SALI = "@COD_DVEN";
            }
            else if (oBe.COD_TIPO_DOCU == 5)
            {
                ALF_NOMB_PROC = "SVPR_NCRE";
                ALF_NOMB_PROC_DETA = "SVPR_NCRE_DETA";
                ALF_NOMB_PROC_GROU = "SVPR_NCRE_GROU";
                ALF_NOMB_PROC_GROU_DETA = "SVPR_NCRE_GROU_DETA";
                ALF_NOMB_PARA_SALI = "@COD_NCRE";
            }

            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand(ALF_NOMB_PROC,
                                                                            oBe.COD_DOCU_SECU,
                                                                            oBe.COD_DOCU_INIC,
                                                                            oBe.COD_SUCU,
                                                                            oBe.COD_SOCI_NEGO,
                                                                            oBe.ALF_NOMB,
                                                                            oBe.FEC_REGI,
                                                                            oBe.FEC_DOCU,
                                                                            oBe.FEC_VENC,
                                                                            oBe.ALF_DIRE,
                                                                            oBe.ALF_CONT,
                                                                            oBe.NUM_DESC,
                                                                            oBe.ALF_OBSE,
                                                                            oBe.NUM_SUBT,
                                                                            oBe.NUM_IGVV,
                                                                            oBe.NUM_ISCC,
                                                                            oBe.NUM_TOTA,
                                                                            oBe.ALF_TOTA,
                                                                            oBe.COD_MONE,
                                                                            oBe.FEC_ENTR,
                                                                            oBe.ALF_SERI,
                                                                            oBe.NUM_CORR,
                                                                            oBe.COD_COMP,
                                                                            oBe.COD_ALMA,
                                                                            oBe.COD_PROY,
                                                                            oBe.ALF_ATEN,
                                                                            oBe.IND_FACT,
                                                                            oBe.COD_USUA_CREA,
                                                                            oBe.COD_USUA_MODI,
                                                                            oBe.ALF_COND_COME,
                                                                            oBe.COD_MOTI, 
                                                                            oBe.IND_FACT_NCRE,
                                                                            oBe.COD_EJEC_COME,
                                                                            oBe.IND_IMPU,
                                                                            oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_DOCU_SECU = Convert.ToInt32(odb.GetParameterValue(ocmd, ALF_NOMB_PARA_SALI));

                        if (oBe.NUM_ACCI != 3)
                        {
                            DbCommand cmdo;

                            oBe.LST_COTI.ForEach(item =>
                            {
                                cmdo = odb.GetStoredProcCommand(ALF_NOMB_PROC_DETA,
                                                                                oBe.COD_DOCU_SECU,
                                                                                item.COD_ARTI,
                                                                                item.ALF_ARTI,
                                                                                item.NUM_PREC_UNIT,
                                                                                item.NUM_PORC_DESC,
                                                                                item.NUM_DESC,
                                                                                item.NUM_CANT,
                                                                                item.NUM_CANT_DESP,
                                                                                item.NUM_STOC_REAL,
                                                                                item.NUM_STOC_VIRT,
                                                                                item.NUM_IMPO,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                1);
                                cmdo.CommandTimeout = 2000;
                                odb.ExecuteNonQuery(cmdo, obts);
                            });

                            oBe.LST_COTI_DETA.ForEach(item =>
                            {
                                cmdo = odb.GetStoredProcCommand(ALF_NOMB_PROC_DETA,
                                                                                oBe.COD_DOCU_SECU,
                                                                                item.COD_ARTI,
                                                                                item.ALF_ARTI,
                                                                                item.NUM_PREC_UNIT,
                                                                                item.NUM_PORC_DESC,
                                                                                item.NUM_DESC,
                                                                                item.NUM_CANT,
                                                                                item.NUM_CANT_DESP,
                                                                                item.NUM_STOC_REAL,
                                                                                item.NUM_STOC_VIRT,
                                                                                item.NUM_IMPO,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                4);
                                cmdo.CommandTimeout = 2000;
                                odb.ExecuteNonQuery(cmdo, obts);
                            });

                            oBe.LST_COTI_GROU.ForEach(item =>
                            {
                                cmdo = odb.GetStoredProcCommand(ALF_NOMB_PROC_GROU,
                                                                                item.COD_COTI_GROU,
                                                                                oBe.COD_DOCU_SECU,
                                                                                item.ALF_NOMB,
                                                                                item.NUM_CANT,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                1);
                                cmdo.CommandTimeout = 2000;
                                odb.ExecuteNonQuery(cmdo, obts);
                            });

                            oBe.LST_COTI_ARTI_GROU.ForEach(item =>
                            {
                                cmdo = odb.GetStoredProcCommand(ALF_NOMB_PROC_GROU_DETA,
                                                                                item.COD_COTI_GROU,
                                                                                oBe.COD_DOCU_SECU,
                                                                                item.COD_ARTI,
                                                                                item.ALF_ARTI,
                                                                                item.NUM_PREC_UNIT,
                                                                                item.NUM_PORC_DESC,
                                                                                item.NUM_DESC,
                                                                                item.NUM_CANT,
                                                                                item.NUM_IMPO,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                1);
                                cmdo.CommandTimeout = 2000;
                                odb.ExecuteNonQuery(cmdo, obts);
                            });

                            if (oBe.COD_TIPO_DOCU == 4)
                            {
                                oBe.LST_GREM.ForEach(item =>
                                {
                                    cmdo = odb.GetStoredProcCommand("SVPR_DVEN_GREM",
                                                                        oBe.COD_DOCU_SECU,
                                                                        item.COD_GREM,
                                                                        oBe.COD_USUA_CREA,
                                                                        oBe.COD_USUA_MODI,
                                                                        1);
                                    cmdo.CommandTimeout = 2000;
                                    odb.ExecuteNonQuery(cmdo, obts);
                                });
                            }

                            if (oBe.COD_TIPO_DOCU == 2 || oBe.COD_TIPO_DOCU == 3)
                            {
                                cmdo = odb.GetStoredProcCommand("SVPR_ACTU_COMP", oBe.COD_USUA_CREA, oBe.COD_ALMA);
                                cmdo.CommandTimeout = 2000;
                                odb.ExecuteNonQuery(cmdo, obts);
                            }
                        }
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

        /// <summary>
        /// REALIZAR OPERACIONES DE MANTENIMIENTO PARA LA VENTA
        /// </summary>
        /// <param name="oBe"></param>
        public void Set_SVPR_OVEN(BESVTC_OVEN oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_OVEN",
                                                                            oBe.COD_OVEN,
                                                                            oBe.COD_COTI,
                                                                            oBe.COD_SUCU,
                                                                            oBe.COD_SOCI_NEGO,
                                                                            oBe.ALF_NOMB,
                                                                            oBe.FEC_REGI,
                                                                            oBe.FEC_DOCU,
                                                                            oBe.FEC_PAGO,
                                                                            oBe.ALF_DIRE,
                                                                            oBe.ALF_CONT,
                                                                            oBe.NUM_DESC,
                                                                            oBe.ALF_OBSE,
                                                                            oBe.NUM_SUBT,
                                                                            oBe.NUM_IGVV,
                                                                            oBe.NUM_ISCC,
                                                                            oBe.NUM_TOTA,
                                                                            oBe.ALF_TOTA,
                                                                            oBe.COD_MONE,
                                                                            oBe.COD_USUA_CREA,
                                                                            oBe.COD_USUA_MODI,
                                                                            oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_OVEN = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_OVEN"));
                        DbCommand cmdo;

                        oBe.LST_OVEN.ForEach(item =>
                        {
                            cmdo = odb.GetStoredProcCommand("SVPR_OVEN_DETA",
                                                                            oBe.COD_OVEN,
                                                                            item.COD_ARTI,
                                                                            item.ALF_ARTI,
                                                                            item.NUM_PREC_UNIT,
                                                                            item.NUM_PORC_DESC,
                                                                            item.NUM_DESC,
                                                                            item.NUM_CANT,
                                                                            item.NUM_STOC_REAL,
                                                                            item.NUM_STOC_VIRT,
                                                                            item.NUM_IMPO,
                                                                            oBe.COD_USUA_CREA,
                                                                            oBe.COD_USUA_MODI,
                                                                            1);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                        });

                        oBe.LST_OVEN_GROU.ForEach(item =>
                        {
                            cmdo = odb.GetStoredProcCommand("SVPR_OVEN_GROU",
                                                                            item.COD_OVEN_GROU,
                                                                            oBe.COD_OVEN,
                                                                            item.ALF_NOMB,
                                                                            item.NUM_CANT,
                                                                            oBe.COD_USUA_CREA,
                                                                            oBe.COD_USUA_MODI,
                                                                            1);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                        });

                        oBe.LST_OVEN_ARTI_GROU.ForEach(item =>
                        {
                            cmdo = odb.GetStoredProcCommand("SVPR_OVEN_GROU_DETA",
                                                                            item.COD_OVEN_GROU,
                                                                            oBe.COD_OVEN,
                                                                            item.COD_ARTI,
                                                                            item.ALF_ARTI,
                                                                            item.NUM_PREC_UNIT,
                                                                            item.NUM_PORC_DESC,
                                                                            item.NUM_DESC,
                                                                            item.NUM_CANT,
                                                                            item.NUM_IMPO,
                                                                            oBe.COD_USUA_CREA,
                                                                            oBe.COD_USUA_MODI,
                                                                            1);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                        });

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
        public IDataReader SVPR_VALI_FACT_LIST(BESVTC_COTI oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_VALI_FACT",oBe.ALF_NUME_GUIA);
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
        public void Set_SVPR_DOCU_ESTA(BESVTC_COTI oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_DOCU_ESTA",
                                                                            oBe.COD_COTI,
                                                                            oBe.COD_USUA_MODI,
                                                                            oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);

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