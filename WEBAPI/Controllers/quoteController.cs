using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Sales;
using BusinessRules.Sales;
using System.Web;
using BusinessEntities.Management;
using BusinessRules.Management;
using BusinessEntities.Generics;
using BusinessRules.Generics;
using BusinessEntities.Warehouse;

namespace WEBAPI.Controllers
{
    public class quoteController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE COTIZACIONES
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WAGSVPR_COTI_LIST")]
        public List<BESVTC_COTI> Get_SVPR_COTI_LIST(BESVTC_COTI oBe)
        {
            if (HttpContext.Current.Session["COD_COMP"] == null)
                return new List<BESVTC_COTI>();
            var oBr = new BRSVTC_COTI();
            oBe.COD_COMP = (int)HttpContext.Current.Session["COD_COMP"];
            var oList = oBr.Get_SVPR_COTI_BUSC(oBe);

            return oList;
        }
        /// <summary>
        /// OBTENER LA LISTA DE EJECUTIVOS COMERCIALES
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WAGSVPR_EJEC_COME")]
        public List<BESVMC_SOCI_NEGO> Get_SVPR_EJEC_COME(BESVMC_SOCI_NEGO oBe)
        {
            if (HttpContext.Current.Session["COD_COMP"] == null)
                return new List<BESVMC_SOCI_NEGO>();

            var oBr = new BRSVMC_SOCI_NEGO();

            oBe.COD_COMP = (int)HttpContext.Current.Session["COD_COMP"];
            var oList = oBr.Get_SVPR_SOCI_NEGO_LIST(oBe);

            return oList;
        }
        /// <summary>
        /// OBTENER LA LISTA DE MONEDAS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WAGSVPR_MONE")]
        public List<BESVMC_MONE> Get_SVPR_MONE(BESVMC_MONE oBe)
        {
            if (HttpContext.Current.Session["COD_COMP"] == null)
                return new List<BESVMC_MONE>();

            var oBr = new BRSVMC_MONE();

            oBe.COD_COMP = (int)HttpContext.Current.Session["COD_COMP"];
            var oList = oBr.Get_SVPR_MONE_LIST(oBe);

            return oList;
        }
        /// <summary>
        /// OBTENER LA LISTA DE MOTIVOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WAGSVPR_MOTI")]
        public List<BEReason> Get_SVPR_MOTI(BEReason oBe)
        {
            if (HttpContext.Current.Session["COD_COMP"] == null)
                return new List<BEReason>();

            oBe.COD_COMP = (int)HttpContext.Current.Session["COD_COMP"];
            oBe.COD_TIPO_MOTI = 2;
            var oBr = new BRSVMC_MOTI();
            var oList = oBr.Get_SVPR_MOTI_LIST(oBe);

            return oList;
        }
        /// <summary>
        /// OBTENER LA LISTA DE PROYECTOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WAGSVPR_PROY")]
        public List<BESVMC_PROY> Get_SVPR_PROY(BESVMC_PROY oBe)
        {
            if (HttpContext.Current.Session["COD_COMP"] == null)
                return new List<BESVMC_PROY>();

            var oBr = new BRSVMC_PROY();

            oBe.COD_COMP = (int)HttpContext.Current.Session["COD_COMP"];
            var oList = oBr.Get_SVPR_PROY_LIST(oBe);

            return oList;
        }
        /// <summary>
        /// OBTENER LA LISTA DE SUCURSALES POR SOCIO DE NEGOCIO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WAGSVPR_SUCU")]
        public List<BESVMD_SOCI_NEGO_SUCU> Get_SVPR_SUCU(BESVMD_SOCI_NEGO_SUCU oBe)
        {
            if (HttpContext.Current.Session["COD_COMP"] == null)
                return new List<BESVMD_SOCI_NEGO_SUCU>();

            var oBr = new BRSVMD_SOCI_NEGO_SUCU();

            var oList = oBr.Get_SVPR_SOCI_NEGO_SUCU_LIST(oBe);
            return oList;
        }
        /// <summary>
        /// OBTENER EL DETALLE DE LA COTIZACION
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WAGSVPR_DETA")]
        public List<BESVTD_COTI> Get_SVPR_DETA(BESVTD_COTI oBe)
        {
            if (HttpContext.Current.Session["COD_COMP"] == null)
                return new List<BESVTD_COTI>();

            var oBr = new BRSVTD_COTI();

            oBe.COD_TIPO_DOCU = 1;
            var oList = oBr.Get_SVPR_COTI_DETA_LIST(oBe);

            return oList;
        }
        /// <summary>
        /// ANULAR COTIZACION
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WASSVPR_COTI_ANUL")]
        public BESVTC_COTI  Set_SVPR_COTI_ANUL(BESVTC_COTI oBe)
        {
            try
            {
                var oBr = new BRSVTC_COTI();

                oBe.COD_COMP = (int)HttpContext.Current.Session["COD_COMP"];

                oBr.Set_SVPR_COTI(oBe);

                oBe.ALF_ESTA = "CANCELADA";
                oBe.IND_ERRO = false;
                oBe.ALF_ERRO = "";
                return oBe;
            }
            catch (Exception ex)
            {
                oBe.IND_ERRO = true;
                oBe.ALF_ERRO = ex.Message;
                return oBe;
            }
        }
    }
}
