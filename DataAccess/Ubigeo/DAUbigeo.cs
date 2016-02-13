using BusinessEntities.Ubigeo;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Ubigeo
{
    public class DAUbigeo
    {
        private Database odb;
        private DbConnection ocn;

        public DAUbigeo()
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

        ~DAUbigeo()
        {
            Dispose(false);
        }

        public IDataReader Get_SVPR_PAIS_LIST(BESVMC_PAIS oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_PAIS_LIST",
                                                    oBe.COD_PAIS,
                                                    oBe.ALF_PAIS,
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

        public void Set_SVPR_PAIS(BESVMC_PAIS oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_PAIS", oBe.COD_PAIS,
                                                                                oBe.COD_COMP,
                                                                                oBe.ALF_PAIS,
                                                                                oBe.ALF_IMPU,
                                                                                oBe.NUM_PORC_IMPU,
                                                                                oBe.ALF_DESC,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_PAIS = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_PAIS"));
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

        public IDataReader Get_SVPR_DEPA_LIST(BESVMC_DEPA oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_DEPA_LIST",
                                                    oBe.COD_PAIS,
                                                    oBe.COD_DEPA,
                                                    oBe.ALF_DEPA,
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

        public IDataReader Get_SVPR_PROV_LIST(BESVMC_PROV oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_PROV_LIST",
                                                    oBe.COD_DEPA,
                                                    oBe.COD_PROV,
                                                    oBe.ALF_PROV,
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

        public IDataReader Get_SVPR_DIST_LIST(BESVMC_DIST oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_DIST_LIST",
                                                    oBe.COD_DEPA,
                                                    oBe.COD_PROV,
                                                    oBe.COD_DIST,
                                                    oBe.ALF_DIST,
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
