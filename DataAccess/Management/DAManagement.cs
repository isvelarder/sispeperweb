using BusinessEntities.Generics;
using BusinessEntities.Management;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Management
{
    public class DAManagement : IDisposable
    {
        private Database odb;
        private DbConnection ocn;

        public DAManagement()
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

        ~DAManagement()
        {
            Dispose(false);
        }

        public IDataReader Get_SVPR_SOCI_NEGO_LIST(BESVMC_SOCI_NEGO oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_SOCI_NEGO_LIST",
                                                                        oBe.COD_SOCI_NEGO,
                                                                        oBe.COD_COMP,
                                                                        oBe.COD_TIPO_SOCI,
                                                                        oBe.ALF_NOMB,
                                                                        oBe.COD_TIPO_IDEN,
                                                                        oBe.ALF_NUME_IDEN,
                                                                        oBe.COD_EJEC_COME,
                                                                        oBe.ALF_DIRE_FISC,
                                                                        oBe.COD_PAIS_DIRE_FISC,
                                                                        oBe.COD_DIST_DIRE_FISC,
                                                                        oBe.COD_PROV_DIRE_FISC,
                                                                        oBe.COD_DEPA_DIRE_FISC,
                                                                        oBe.COD_PAIS_DIRE_FACT,
                                                                        oBe.ALF_DIRE_RECE_FACT,
                                                                        oBe.COD_DIST_RECE_FACT,
                                                                        oBe.COD_PROV_RECE_FACT,
                                                                        oBe.COD_DEPA_RECE_FACT,
                                                                        oBe.COD_COND_PAGO,
                                                                        oBe.ALF_TELE,
                                                                        oBe.ALF_FAXX,
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

        public void Set_SVPR_SOCI_NEGO(BESVMC_SOCI_NEGO oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_SOCI_NEGO", 
                                                                        oBe.COD_SOCI_NEGO,
                                                                        oBe.COD_COMP,
                                                                        oBe.COD_TIPO_SOCI,
                                                                        oBe.ALF_NOMB,
                                                                        oBe.COD_TIPO_IDEN,
                                                                        oBe.ALF_NUME_IDEN,
                                                                        oBe.COD_EJEC_COME,
                                                                        oBe.ALF_DIRE_FISC,
                                                                        oBe.COD_PAIS_DIRE_FISC,
                                                                        oBe.COD_DIST_DIRE_FISC,
                                                                        oBe.COD_PROV_DIRE_FISC,
                                                                        oBe.COD_DEPA_DIRE_FISC,
                                                                        oBe.COD_PAIS_DIRE_FACT,
                                                                        oBe.ALF_DIRE_RECE_FACT,
                                                                        oBe.COD_DIST_RECE_FACT,
                                                                        oBe.COD_PROV_RECE_FACT,
                                                                        oBe.COD_DEPA_RECE_FACT,
                                                                        oBe.COD_COND_PAGO == 0 ? null : oBe.COD_COND_PAGO,
                                                                        oBe.ALF_TELE,
                                                                        oBe.ALF_FAXX,
                                                                        oBe.COD_USUA_CREA,
                                                                        oBe.COD_USUA_MODI,
                                                                        oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_SOCI_NEGO = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_SOCI_NEGO"));
                        DbCommand cmdo;

                        oBe.LST_SUCU.ForEach(item =>
                        {
                            cmdo = odb.GetStoredProcCommand("SVPR_SOCI_NEGO_SUCU",
                                                                            item.COD_SOCI_NEGO_SUCU,
                                                                            oBe.COD_SOCI_NEGO,
                                                                            item.ALF_SUCU,
                                                                            item.ALF_DIRE,
                                                                            item.COD_PAIS,
                                                                            item.COD_DEPA,
                                                                            item.COD_PROV,
                                                                            item.COD_DIST,
                                                                            oBe.COD_USUA_CREA,
                                                                            oBe.COD_USUA_MODI,
                                                                            1);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                        });

                        oBe.LST_CONT.ForEach(item =>
                        {
                            cmdo = odb.GetStoredProcCommand("SVPR_SOCI_NEGO_CONT",
                                                                            item.COD_SOCI_NEGO_SUCU,
                                                                            oBe.COD_SOCI_NEGO,
                                                                            item.COD_TIPO_CONT,
                                                                            item.ALF_CONT,
                                                                            item.ALF_EMAI,
                                                                            item.ALF_TELE,
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

        public IDataReader Get_SVPR_SOCI_NEGO_CONT_LIST(BESVMD_SOCI_NEGO_CONT oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_SOCI_NEGO_CONT_LIST",
                                                                        oBe.COD_SOCI_NEGO_SUCU,
                                                                        oBe.COD_SOCI_NEGO,
                                                                        oBe.COD_TIPO_CONT,
                                                                        oBe.ALF_CONT,
                                                                        oBe.ALF_EMAI,
                                                                        oBe.ALF_TELE,
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

        public IDataReader Get_SVPR_SOCI_NEGO_SUCU_LIST(BESVMD_SOCI_NEGO_SUCU oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_SOCI_NEGO_SUCU_LIST",
                                                                        oBe.COD_SOCI_NEGO_SUCU,
                                                                        oBe.COD_SOCI_NEGO,
                                                                        oBe.ALF_SUCU,
                                                                        oBe.ALF_DIRE,
                                                                        oBe.COD_PAIS,
                                                                        oBe.ALF_DEPA,
                                                                        oBe.ALF_PROV,
                                                                        oBe.ALF_DIST,
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

        public IDataReader Get_SVPR_TIPO_CAMB_LIST(BESVMC_TIPO_CAMB oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_CAMB_LIST",
                                                                        oBe.COD_TIPO_CAMB,
                                                                        oBe.COD_COMP,
                                                                        oBe.FEC_TIPO_CAMB,
                                                                        oBe.NUM_TIPO_CAMB_COMP,
                                                                        oBe.NUM_TIPO_CAMB_VENT,
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

        public void Set_SVPR_TIPO_CAMB(BESVMC_TIPO_CAMB oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_CAMB",
                                                                        oBe.COD_TIPO_CAMB,
                                                                        oBe.COD_COMP,
                                                                        oBe.FEC_TIPO_CAMB,
                                                                        oBe.NUM_TIPO_CAMB_COMP,
                                                                        oBe.NUM_TIPO_CAMB_VENT,
                                                                        oBe.COD_USUA_CREA,
                                                                        oBe.COD_USUA_MODI,
                                                                        oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_TIPO_CAMB = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_TIPO_CAMB"));
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
