using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessEntities.Warehouse
{
    public static class WhMessage
    {
        public const string MsgInsCaption = "Información del Sistema.";

        public const string MsgReqALF_ARTI = "Nombre de artículo incorrecto.";
        public const string MsgReqALF_ARTI1 = "Artículo incorrecto.";
        public const string MsgLenALF_ARTI = "La longitud del nombre artículo\nsolo admite 50 caracteres.";
        public const string MsgReqALF_CODI_ARTI = "Código de artículo incorrecto.";
        public const string MsgLenALF_CODI_ARTI = "La longitud del código de artículo\nsolo admite 30 caracteres.";
        public const string MsgOpenFile = "Desea abrir el archivo?";

        public const string MsgReqALF_TIPO_ARTI = "Tipo de artículo incorrecto.";
        public const string MsgLenALF_TIPO_ARTI = "La longitud del tipo de artículo\nsolo admite 50 caracteres.";

        public const string MsgReqALF_MODE_ARTI = "Modelo de artículo incorrecto.";
        public const string MsgLenALF_MODE_ARTI = "La longitud del modelo de artículo\nsolo admite 50 caracteres.";

        public const string MsgReqALF_ALMA = "Almacén incorrecto.";
        public const string MsgLenALF_ALMA = "La longitud del almacén\nsolo admite 150 caracteres.";
        public const string MsgReqCOD_SOCI_NEGO_ENCA = "Encargado incorrecto.";

        public const string MsgReqCOD_SOCI_NEGO_RESP = "Responsable incorrecto.";
        public const string MsgReqCOD_MOTI = "Motivo incorrecto.";
        public const string MsgReqFEC_ENTR = "Fecha de entrega incorrecta.";
        public const string MsgReqFEC_REGI = "Fecha de registro incorrecta.";
        public const string MsgReqFEC_SALI = "Fecha de salida incorrecta.";
        public const string MsgReqFEC_TRAN = "Fecha de transferencia incorrecta.";
        public const string MsgReqFEC_RECE = "Fecha de recepción incorrecta.";

        public const string MsgReqALF_TIPO_MOTI = "Tipo de motivo incorrecto.";
        public const string MsgLenALF_TIPO_MOTI = "La longitud del tipo de motivo\nsolo admite 50 caracteres.";

        public const string MsgReqALF_MOTI = "Motivo incorrecto.";
        public const string MsgLenALF_MOTI = "La longitud del motivo\nsolo admite 50 caracteres.";

        public const string MsgConExport = "Desea abrir el archivo?";
        public const string MsgSelFile = "Seleccione una ruta para guardar el archivo.";
        public const string MsgFilExport = "Excel|*.xlsx";
        public const string MsgSelImage = "Seleccione una imagen para cargarla.";
        public const string MsgFilImage = "Imagenes|*.png;*.bmp;*.jpg;*gif";

        public const string MsgZeroRows = "No existen registros para\nrealizar esta operación.";
        public const string MsgSuccessfully = "Operación concretada con exito.";

        public const string MsgMinNUM_CANT = "Cantidad incorrecta.";
        public const string MsgExistArticle = "El artículo seleccionado ya esta en la lista,\nsi desea actualize la cantidad.";

        public const string MsgManyRows = "Agregar al menos un registro a la lista.";
        public const string MsgManyWhArt = "No puede existir artículos\ncon diferentes almacenes.";

        public const string MsgNotModyRegis = "No es posible modificar el registro.";
        public const string MsgReqALF_LIST_PREC = "Nombre de lista de precios incorrecto.";
        public const string MsgReqIND_TIPO_LIST = "Tipo de lista incorrecto.";
        public const string MsgReqNUM_PREC = "Precio incorrecto.";
    }
}
