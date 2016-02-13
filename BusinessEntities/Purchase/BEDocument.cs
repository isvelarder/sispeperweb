using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessEntities.Purchase
{
    public class BEDocument
    {
        public int? COD_ORCO { get; set; }
        public int? COD_DOCU { get; set; }
        public string ALF_DOCU_REFE { get; set; }
        public string ALF_NUME_DOCU { get; set; }
        public string ALF_NUM_SERI { get; set; }
        public string ALF_NUM_CORR { get; set; }
        public string IND_ESTA { get; set; }
        public int COD_SUCU { get; set; }
        public string IND_TIPO_COMP { get; set; }
        [Required(ErrorMessage = _Message.MsgReqCOD_SOCI_NEGO)]
        public int? COD_SOCI_NEGO { get; set; }
        [Required(ErrorMessage = _Message.MsgReqCOD_SOCI_NEGO)]
        public string ALF_SOCI_NEGO { get; set; }
        public string ALF_NUM_RUCC { get; set; }
        public int? ALF_CONT { get; set; }
        //[Required(ErrorMessage = _Message.MsgReqALF_DIRE_FISC)]
        public string ALF_DIRE_FISC { get; set; }
        [Required(ErrorMessage = _Message.MsgReqALF_DIRE_ENTR)]
        public string ALF_DIRE_ENTR { get; set; }
        public int? COD_MONE { get; set; }
        public decimal? NUM_TIPO_CAMB { get; set; }
        [Required(ErrorMessage = _Message.MsgReqCOD_COND_PAGO)]
        public int? COD_COND_PAGO { get; set; }
        [Required(ErrorMessage = _Message.MsgReqALF_ALMA)]
        public int? COD_ALMA { get; set; }
        public string ALF_ALMA { get; set; }
        public string ALF_COND_PAGO { get; set; }
        [Required(ErrorMessage = _Message.MsgReqFEC_REGI)]
        public DateTime? FEC_REGI { get; set; }
        [Required(ErrorMessage = _Message.MsgReqFEC_ENTR)]
        public DateTime? FEC_ENTR { get; set; }
        [Required(ErrorMessage = _Message.MsgReqFEC_DOCU)]
        public DateTime? FEC_DOCU { get; set; }
        [Required(ErrorMessage = _Message.MsgReqFEC_PAGO)]
        public DateTime? FEC_PAGO { get; set; }
        public string ALF_COME { get; set; }
        public decimal NUM_SUBB_TOTA { get; set; }
        public decimal NUM_DESC { get; set; }
        public decimal NUM_IGVV { get; set; }
        public decimal NUM_ISCC { get; set; }
        public decimal NUM_TOTA { get; set; }
        public string COD_USUA_CREA { get; set; }
        public DateTime? FEC_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public DateTime? FEC_MODI { get; set; }

        public string ALF_MONE_SIMB { get; set; }
        public decimal NUM_MONT { get; set; }
        public string ALF_CONC_GANA { get; set; }
        public string ALF_CODI_ARTI { get; set; }
        public string ALF_ARTI { get; set; }
        public decimal NUM_IMPO { get; set; }
        public decimal NUM_CANT { get; set; }
        public DateTime? FEC_REGI_INIC { get; set; }
        public DateTime? FEC_REGI_FINA { get; set; }
        public string ALF_NUME_GUIA { get; set; }
        public string ALF_NUME_FACT { get; set; }
        public string IND_TIPO_IMPO { get; set; }


        public int IND_MNTN { get; set; }
        public string MSG_MNTN { get; set; }
    }
}
