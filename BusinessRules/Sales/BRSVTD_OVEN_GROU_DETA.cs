﻿using BusinessEntities.Generics;
using DataAccess.Generics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultSetMappers;
using DataAccess.Warehouse;
using BusinessEntities.Warehouse;
using DataAccess.Sales;
using BusinessEntities.Sales;

namespace BusinessRules.Sales
{
    public class BRSVTD_OVEN_GROU_DETA : IDisposable
    {
        private DASales oDa;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (oDa != null)
                {
                    oDa.Dispose();
                    oDa = null;
                }
        }
        ~BRSVTD_OVEN_GROU_DETA()
        {
            Dispose(false);
        }
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        public BRSVTD_OVEN_GROU_DETA()
        {
            oDa = new DASales();
        }
        /// <summary>
        /// OBTENER EL RESULTADO DE CUALQUIER CONSULTA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESVTD_OVEN> Get_SVPR_OVEN_GROU_DETA_LIST(BESVTD_OVEN oBe)
        {
            try
            {
                using (IDataReader oDr = oDa.Get_SVPR_OVEN_GROU_DETA_LIST(oBe))
                {
                    List<BESVTD_OVEN> oList = new List<BESVTD_OVEN>();
                    IList iList = oList;
                    ((IList)iList).LoadFromReader<BESVTD_OVEN>(oDr);
                    Dispose(false);
                    return (oList);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
