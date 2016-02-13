using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessEntities.Purchase
{
    public static class _Message
    {
        public const string MsgInsCaption = "Información del Sistema.";
        public const string MsgReqALF_CODI_ARTI = "Artículo incorrecto.";
        public const string MsgReqALF_NUM_SERI = "Número de serie incorrecto.";
        public const string MsgReqALF_NUM_CORR = "Número de correlativo incorrecto.";
        public const string MsgReqALF_ALMA = "Almacén incorrecto.";
        public const string MsgReqCOD_SOCI_NEGO = "Proveedor incorrecto.";
        public const string MsgReqALF_DIRE_FISC = "Dirección fiscal incorrecta.";
        public const string MsgReqALF_DIRE_ENTR = "Dirección de entrega incorrecta.";
        public const string MsgReqCOD_COND_PAGO = "Condición de pago incorrecta.";
        public const string MsgSelectCO = "Buscar una cotización para realizar está operación.";

        public const string MsgReqFEC_ENTR = "Fecha de entrega incorrecta.";
        public const string MsgReqFEC_REGI = "Fecha de registro incorrecta.";
        public const string MsgReqFEC_DOCU = "Fecha de documento incorrecta.";
        public const string MsgReqFEC_PAGO = "Fecha de pago incorrecta.";

        public const string MsgConExport = "Desea abrir el archivo?";
        public const string MsgSelFile = "Seleccione una ruta para guardar el archivo.";
        public const string MsgFilExport = "Excel|*.xlsx";

        public const string MsgZeroRows = "No existen registros para\nrealizar esta operación.";
        public const string MsgSuccessfully = "Operación concretada con exito.";

        public const string MsgMinNUM_CANT = "Cantidad incorrecta.";
        public const string MsgExistArticle = "El artículo seleccionado ya esta en la lista,\nsi desea actualize la cantidad.";

        public const string MsgManyRows = "Agregar al menos un registro a la lista.";
        public const string MsgNotModyDocu = "No es posible modificar el documento.";
        public const string MsgNotModyDocuSta = "No es posible modificar el documento\nya está ";
        public const string MsgNotModyRegis = "No es posible modificar el registro.";
        public const string MsgNotCopy = "No es posible realizar está operación\n el documento ya está ";
        public const string MsgSelectOC = "Buscar una orden de compra\npara realizar está operación.";
        public const string MsgSelectDoc = "Buscar un documento de compra\npara realizar está operación.";

        public const string MsgReqEX_NUM_DOCU = "Número de documento incorrecto.";
        public const string MsgReqEX_FEC_DOCU = "Fecha de documento incorrecto.";
        public const string MsgReqEX_ALF_NOMB_PROV = "Proveedor del documento incorrecto.";
        public const string MsgReqEX_ALF_RUCC_PROV = "Ruc del proveedor incorrecto.";
        public const string MsgMinEX_NUM_MONT = "Monto del documento incorrecto.";
        public const string MsgReqEX_COD_CONC_GANA = "Concepto incorrecto.";
        public const string MsgReqEX_COD_MONE = "Moneda incorrecta.";
    }
}
