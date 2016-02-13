using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Security;

namespace DataAccess.Security
{
    public class DASecurity
    {
        private Database odb;
        private DbConnection ocn;

        public DASecurity()
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

        ~DASecurity()
        {
            Dispose(false);
        }

        public IDataReader Get_SVPR_ACCE_LIST(BESVMD_ACCE oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_ACCE_LIST",
                                                    oBe.COD_MAIN,
                                                    oBe.COD_PERF,
                                                    oBe.ALF_NOMB,
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

        public IDataReader Get_SVPR_USUA_LIST(BESVMC_USUA oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_USUA_LIST",
                                                    oBe.COD_USUA,
                                                    oBe.COD_SOCI_NEGO,
                                                    oBe.COD_PERF,
                                                    oBe.ALF_PASS,
                                                    oBe.IND_ACTI,
                                                    oBe.COD_COMP,
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

        public IDataReader Get_SVPR_PERF_LIST(BESVMC_PERF oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_PERF_LIST",
                                                    oBe.COD_PERF,
                                                    oBe.COD_COMP,
                                                    oBe.ALF_PERF,
                                                    oBe.ALF_DESC,
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

        public IDataReader Get_SVPR_COMP_LIST(BESVMC_COMP oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_COMP_LIST",
                                                    oBe.COD_COMP,
                                                    oBe.COD_PAIS,
                                                    oBe.COD_DEPA,
                                                    oBe.COD_PROV,
                                                    oBe.COD_DIST,
                                                    oBe.ALF_COMP,
                                                    oBe.ALF_DESC,
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

        /// <summary>
        /// REALIZAR OPERACIONES DE MANTENIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        public void Set_SVPR_PERF(BESVMC_PERF oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_PERF", oBe.COD_PERF,
                                                                            oBe.COD_COMP,
                                                                            oBe.ALF_PERF,
                                                                            oBe.ALF_DESC,
                                                                            oBe.COD_USUA_CREA,
                                                                            oBe.COD_USUA_MODI,
                                                                            oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_PERF = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_PERF"));
                        DbCommand cmdo;

                        oBe.OBJ_ACCE.LST_OPCI.ForEach(item =>
                        {
                            cmdo = odb.GetStoredProcCommand("SVPR_ACCE", 0,
                                                                            oBe.COD_PERF,
                                                                            null,
                                                                            item.COD_OPCI,
                                                                            item.IND_MARC,
                                                                            oBe.COD_USUA_CREA,
                                                                            oBe.COD_USUA_MODI,
                                                                            1);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                        });

                        oBe.OBJ_ACCE.LST_OPCI_BUTT.ForEach(item =>
                        {
                            cmdo = odb.GetStoredProcCommand("SVPR_ACCE", 0,
                                                                            oBe.COD_PERF,
                                                                            item.COD_BUTT,
                                                                            item.COD_OPCI,
                                                                            item.IND_MARC,
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

        public void Set_SVPR_COMP(BESVMC_COMP oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_COMP", oBe.COD_COMP,
                                                                            oBe.COD_PAIS,
                                                                            oBe.COD_DEPA,
                                                                            oBe.COD_PROV,
                                                                            oBe.COD_DIST,
                                                                            oBe.ALF_COMP,
                                                                            oBe.ALF_DESC,
                                                                            oBe.COD_USUA_CREA,
                                                                            oBe.COD_USUA_MODI,
                                                                            oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_COMP = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_COMP"));
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

        public void Set_SVPR_USUA(BESVMC_USUA oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_USUA", oBe.COD_USUA,
                                                                            oBe.COD_SOCI_NEGO,
                                                                            oBe.COD_PERF,
                                                                            oBe.ALF_PASS,
                                                                            oBe.IND_ACTI,
                                                                            oBe.COD_COMP,
                                                                            oBe.COD_USUA_CREA,
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

        public IDataReader Get_SVPR_MAIN_LIST(BESVMC_MAIN_MENU oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_MAIN_LIST",
                                                    oBe.COD_MAIN,
                                                    oBe.ALF_NOMB,
                                                    oBe.ALF_DESC,
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

        public IDataReader Get_SVPR_OPCI_LIST(BESVMC_OPCI oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_OPCI_LIST",
                                                    oBe.COD_OPCI,
                                                    oBe.COD_PERF,
                                                    oBe.ALF_NOMB,
                                                    oBe.ALF_DESC,
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

        public IDataReader Get_SVPR_BUTT_LIST(BESVMC_BUTT oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_BUTT_LIST",
                                                    oBe.COD_BUTT,
                                                    oBe.COD_PERF,
                                                    oBe.ALF_NOMB,
                                                    oBe.ALF_DESC,
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
    }
}