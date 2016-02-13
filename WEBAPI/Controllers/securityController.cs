using BusinessEntities.Security;
using BusinessRules.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    public class securityController : ApiController
    {
        //----------------------------------------------------------------------------------------------------
        //VALIDAR EL CODIGO CAPCHA
        //----------------------------------------------------------------------------------------------------
        [HttpPost]
        [Route("SVPR_CAPC")]
        public string get_SVPR_CAPC([FromBody] string captchaText)
        {
            var captchastring = (string)HttpContext.Current.Session["captchastring"];
            var _ok = (string.Equals(captchaText, captchastring)) ? "1" : "0";
            return (_ok);
        }
        //----------------------------------------------------------------------------------------------------
        //VALIDAR USUARIO Y CONTRASEÑA
        //----------------------------------------------------------------------------------------------------
        [HttpPost]
        [Route("SVPR_USUA")]
        public BESVMC_USUA get_SVPR_USUA(BESVMC_USUA oBe)
        {
            var oBr = new BRSVMC_USUA();
            try
            {
                oBe.COD_COMP = 1;
                oBe.ALF_PASS = BRCryptography.Encrypt(oBe.ALF_PASS);
                oBe.NUM_ACCI = 5;

                var oList = oBr.Get_SVPR_USUA_LIST(oBe);

                if (oList.Count > 0)
                {
                    HttpContext.Current.Session["ALF_NOMB"] = oList[0].ALF_NOMB;
                    HttpContext.Current.Session["COD_PERF"] = oList[0].COD_PERF;
                    HttpContext.Current.Session["ALF_IMPU"] = oList[0].ALF_IMPU;
                    HttpContext.Current.Session["COD_COMP"] = oList[0].COD_COMP;
                    oBe.ALF_NOMB = oList[0].ALF_NOMB;
                    oBe.COD_PERF = oList[0].COD_PERF;
                    oBe.ALF_IMPU = oList[0].ALF_IMPU;
                    oBe.IND_ACTI = true;
                }
                else
                {
                    oBe.IND_ACTI = false;
                }
                oBe.IND_ERRO = false;
            }
            catch (Exception ex)
            {
                oBe.IND_ERRO = true;
                oBe.ALF_ERRO = ex.Message;
            }
            oBe.ALF_PASS = null;
            return oBe;
        }
        //----------------------------------------------------------------------------------------------------
        //OBTENER LA LISTA DE 
        //----------------------------------------------------------------------------------------------------
        [HttpPost]
        [Route("rols")]
        public List<BESVMC_OPCI> get_SVPR_OPCI_LIST()
        {
            if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["ALF_NOMB"]))
                return new List<BESVMC_OPCI>();

            //var oBe = new BESVMC_USUA { COD_USUA = (string)HttpContext.Current.Session["username"] };
            var oBe = new BESVMC_OPCI { NUM_ACCI = 6, COD_PERF = (int)HttpContext.Current.Session["COD_PERF"] };
            var oBr = new BRSVMC_OPCI();
            var oList = oBr.Get_SVPR_OPCI_LIST(oBe);
            return (oList);
        }

        [HttpPost]
        [Route("logoutpper")]
        public string get_LOGOUT()
        {
            HttpContext.Current.Session["ALF_NOMB"] = string.Empty;
            HttpContext.Current.Session["COD_PERF"] = 0;
            HttpContext.Current.Session["ALF_IMPU"] = string.Empty;
            return ("OK");
        }

        [HttpPost]
        [Route("logoutaut")]
        public string get_LOGOUTAUT()
        {
            if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["ALF_NOMB"]))
                return ("KO");
            else
                return("OK");
        }
    }
}
