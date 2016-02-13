using BusinessEntities.Generics;
using BusinessEntities.Sales;
using BusinessEntities.Warehouse;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Generics
{
    public class DAGenerics : IDisposable
    {
        private Database odb;
        private DbConnection ocn;

        public DAGenerics()
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

        ~DAGenerics()
        {
            Dispose(false);
        }

        public IDataReader Get_SVPR_TIPO_SOCI_LIST(BESVMC_TIPO_SOCI oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_SOCI_LIST",
                                                    oBe.COD_TIPO_SOCI,
                                                    oBe.COD_COMP,
                                                    oBe.ALF_TIPO_SOCI,
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

        public IDataReader Get_SVPR_SERI_CORR_LIST(BESVMC_SERI_CORR oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_SERI_CORR_LIST",
                                                    oBe.COD_TIPO_DOCU,
                                                    oBe.ALF_SERI,
                                                    oBe.NUM_CORR,
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

        public void Set_SVPR_SERI_CORR(BESVMC_SERI_CORR oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_SERI_CORR",
                                                                        oBe.COD_TIPO_DOCU,
                                                                        oBe.ALF_SERI,
                                                                        oBe.NUM_CORR,
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

        public void Set_SVPR_TIPO_SOCI(BESVMC_TIPO_SOCI oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_SOCI", oBe.COD_TIPO_SOCI,
                                                                                oBe.COD_COMP,
                                                                                oBe.ALF_TIPO_SOCI,
                                                                                oBe.ALF_DESC,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_TIPO_SOCI = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_TIPO_SOCI"));
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

        public IDataReader Get_SVPR_TIPO_IDEN_LIST(BESVMC_TIPO_IDEN oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_IDEN_LIST",
                                                    oBe.COD_TIPO_IDEN,
                                                    oBe.COD_COMP,
                                                    oBe.ALF_TIPO_IDEN,
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

        public void Set_SVPR_TIPO_IDEN(BESVMC_TIPO_IDEN oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_IDEN", oBe.COD_TIPO_IDEN,
                                                                                oBe.COD_COMP,
                                                                                oBe.ALF_TIPO_IDEN,
                                                                                oBe.ALF_DESC,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_TIPO_IDEN = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_TIPO_IDEN"));
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

        public IDataReader Get_SVPR_TIPO_CONT_LIST(BESVMC_TIPO_CONT oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_CONT_LIST",
                                                    oBe.COD_TIPO_CONT,
                                                    oBe.COD_COMP,
                                                    oBe.ALF_TIPO_CONT,
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

        public void Set_SVPR_TIPO_CONT(BESVMC_TIPO_CONT oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_CONT", oBe.COD_TIPO_CONT,
                                                                                oBe.COD_COMP,
                                                                                oBe.ALF_TIPO_CONT,
                                                                                oBe.ALF_DESC,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_TIPO_CONT = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_TIPO_CONT"));
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

        public IDataReader Get_SVPR_COND_PAGO_LIST(BESVMC_COND_PAGO oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_COND_PAGO_LIST",
                                                    oBe.COD_COND_PAGO,
                                                    oBe.COD_COMP,
                                                    oBe.ALF_COND_PAGO,
                                                    oBe.ALF_DESC,
                                                    oBe.NUM_DIAS,
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

        public void Set_SVPR_COND_PAGO(BESVMC_COND_PAGO oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_COND_PAGO", oBe.COD_COND_PAGO,
                                                                                oBe.COD_COMP,
                                                                                oBe.ALF_COND_PAGO,
                                                                                oBe.ALF_DESC,
                                                                                oBe.NUM_DIAS,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_COND_PAGO = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_COND_PAGO"));
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

        public IDataReader Get_SVPR_SUCU_LIST(BESVMC_SUCU oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_SUCU_LIST",
                                                    oBe.COD_SUCU,
                                                    oBe.COD_COMP,
                                                    oBe.ALF_SUCU,
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

        public void Set_SVPR_SUCU(BESVMC_SUCU oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_SUCU", oBe.COD_SUCU,
                                                                            oBe.COD_COMP,
                                                                                oBe.ALF_SUCU,
                                                                                oBe.ALF_DESC,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_SUCU = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_SUCU"));
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

        public IDataReader Get_SVPR_MOTI_LIST(BEReason oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_MOTI_LIST",
                                                                    oBe.COD_MOTI,
                                                                    oBe.COD_COMP,
                                                                    oBe.ALF_MOTI,
                                                                    oBe.COD_TIPO_MOTI,
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

        public void Set_SVPR_MOTI(BEReason oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_MOTI",
                                                                        oBe.COD_MOTI,
                                                                        oBe.COD_COMP,
                                                                        oBe.ALF_MOTI,
                                                                        oBe.COD_TIPO_MOTI,
                                                                        oBe.COD_USUA_CREA,
                                                                        oBe.COD_USUA_MODI,
                                                                        oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_MOTI = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_MOTI"));
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

        public IDataReader Get_SVPR_MONE_LIST(BESVMC_MONE oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_MONE_LIST",
                                                                    oBe.COD_MONE,
                                                                    oBe.COD_COMP,
                                                                    oBe.ALF_MONE,
                                                                    oBe.ALF_MONE_SIMB,
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

        public void Set_SVPR_MONE(BESVMC_MONE oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_MONE",
                                                                        oBe.COD_MONE,
                                                                        oBe.COD_COMP,
                                                                        oBe.ALF_MONE,
                                                                        oBe.ALF_MONE_SIMB,
                                                                        oBe.COD_USUA_CREA,
                                                                        oBe.COD_USUA_MODI,
                                                                        oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_MONE = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_MONE"));
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
        public IDataReader Get_SVPR_TIPO_DOCU_LIST(BESVMC_TIPO_DOCU oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_DOCU_LIST",
                                                                    oBe.COD_TIPO_DOCU,
                                                                    oBe.COD_COMP,
                                                                    oBe.ALF_TIPO_DOCU,
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

        public void Set_SVPR_TIPO_DOCU(BESVMC_TIPO_DOCU oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_DOCU",
                                                                        oBe.COD_TIPO_DOCU,
                                                                        oBe.COD_COMP,
                                                                        oBe.ALF_TIPO_DOCU,
                                                                        oBe.ALF_DESC,
                                                                        oBe.COD_USUA_CREA,
                                                                        oBe.COD_USUA_MODI,
                                                                        oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_TIPO_DOCU = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_TIPO_DOCU"));
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

        public IDataReader Get_SVPR_TIPO_ARTI_LIST(BESVMC_TIPO_ARTI oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_ARTI_LIST",
                                                    oBe.COD_TIPO_ARTI,
                                                    oBe.COD_COMP,
                                                    oBe.ALF_TIPO_ARTI,
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

        public void Set_SVPR_TIPO_ARTI(BESVMC_TIPO_ARTI oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_TIPO_ARTI", oBe.COD_TIPO_ARTI,
                                                                                oBe.COD_COMP,
                                                                                oBe.ALF_TIPO_ARTI,
                                                                                oBe.ALF_DESC,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_TIPO_ARTI = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_TIPO_ARTI"));
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

        public IDataReader Get_SVPR_MODE_ARTI_LIST(BESVMC_MODE_ARTI oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_MODE_ARTI_LIST",
                                                    oBe.COD_MODE_ARTI,
                                                    oBe.COD_COMP,
                                                    oBe.ALF_MODE_ARTI,
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

        public void Set_SVPR_MODE_ARTI(BESVMC_MODE_ARTI oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_MODE_ARTI", oBe.COD_MODE_ARTI,
                                                                                oBe.COD_COMP,
                                                                                oBe.ALF_MODE_ARTI,
                                                                                oBe.ALF_DESC,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_MODE_ARTI = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_MODE_ARTI"));
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
        public IDataReader Get_SVPR_PROY_LIST(BESVMC_PROY oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("SVPR_PROY_LIST",
                                                    oBe.COD_PROY,
                                                    oBe.ALF_PROY,
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

        public void Set_SVPR_PROY(BESVMC_PROY oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("SVPR_PROY", oBe.COD_PROY,
                                                                                oBe.ALF_PROY,
                                                                                oBe.COD_COMP,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.COD_PROY = Convert.ToInt32(odb.GetParameterValue(ocmd, "@COD_PROY"));
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
