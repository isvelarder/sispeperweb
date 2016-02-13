app.controller('controllerQuote', function ($scope, $http) {
    //-----------------------------------------------------------------------------------------------------//
    //DEFINICIONES INICIALES
    //-----------------------------------------------------------------------------------------------------//
    Globalize.culture('es-PE');
    document.getElementById('titleform').innerHTML = 'Cotización';
    var hgt1 = $('#mainContent').height();
    var hgt2 = $('#Filter').height();
    $scope.hgt = hgt1 - (hgt2 + 40);

    $scope.date = new Date();

    //-----------------------------------------------------------------------------------------------------//
    //CARGAR INFORMACION DE LA BUSQUEDA EN FUNCION A LOS PARAMETROS DE BUSQUEDA
    //-----------------------------------------------------------------------------------------------------//
    $scope.GetSearchQuote = function () {
        $http.post('../WAGSVPR_COTI_LIST',
                    JSON.stringify({
                        ALF_NUME_IDEN: $("#txtALF_NUM_DOCU").dxTextBox("instance").option("value"),
                        FEC_DESD : $("#deFEC_DESD").dxDateBox("instance").option("value"),
                        FEC_HAST: $("#deFEC_HAST").dxDateBox("instance").option("value"),
                        COD_TIPO_DOCU:1,
                        NUM_ACCI : 5
                    }),
                    { headers: { 'Content-Type': 'application/json' } })
        .success(function (data) {
            $('#gdvQuote').dxDataGrid({ dataSource: data });
        });
    }
    //-----------------------------------------------------------------------------------------------------//
    //CELL TEMPLATE PARA PRIMERA COLUMNA DE LA COTIZACIÓN
    //-----------------------------------------------------------------------------------------------------//
    $scope.cellTemplate = function (container, options) {
        if (options.data.COD_ESTA === 1) {
            $('<span id="spanicon" title="Editar" />')
                .addClass("dx-icon-edit icon")
                .on("dxclick", function (e) {
                    $scope.GetQuoteView(options.data);
                })
                .appendTo(container);
        }
        else {
            $('<span id="spanicon" title="Editar" />')
                .addClass("dx-icon-find icon")
                .on("dxclick", function (e) {
                    console.log("Visualizar cotización");
                })
                .appendTo(container);
        }
    };
    //-----------------------------------------------------------------------------------------------------//
    //CELL TEMPLATE PARA PRIMERA COLUMNA DE LA COTIZACIÓN
    //-----------------------------------------------------------------------------------------------------//
    $scope.cellTemplateDetail = function (container, options) {
        $('<span id="spanicon" title="Editar" />')
            .addClass("dx-icon-remove icon")
            .on("dxclick", function (e) {
                console.log("articulo eliminado");
            })
            .appendTo(container);
    };
    //-----------------------------------------------------------------------------------------------------//
    //HEADER TEMPLATE PARA PRIMERA COLUMNA DEL DETALLE DE LA COTIZACION
    //-----------------------------------------------------------------------------------------------------//
    $scope.headerTemplate = function (container, options) {
        $('<span id="spanicon" title="Agregar" />')
            .addClass("dx-icon-add icon")
            .on("dxclick", function (e) {
                alert("Agregar Articulo");
            })
            .appendTo(container);
    };
    //-----------------------------------------------------------------------------------------------------//
    //MOSTRAR VENTANA DE COTIZACIÓN
    //-----------------------------------------------------------------------------------------------------//
    $scope.GetQuoteView = function (obj) {
        $("#popupQuote").dxPopup("instance").show();
        $scope.ClearControl();
        $scope.StateControl(true);
        //CARGAR LA LISTA DE EJECUTIVOS COMERCIALES
        $http.post('../WAGSVPR_EJEC_COME',
                JSON.stringify({
                    NUM_ACCI: 5
                }),
                { headers: { 'Content-Type': 'application/json' } })
        .success(function (data) {
            $('#cmbCOD_EJEC_COME').dxSelectBox({ dataSource: data });
        });
        //CARGAR LA LISTA DE MONEDAS
        $http.post('../WAGSVPR_MONE',
                JSON.stringify({
                    NUM_ACCI: 4
                }),
                { headers: { 'Content-Type': 'application/json' } })
        .success(function (data) {
            $('#cmbCOD_MONE').dxSelectBox({ dataSource: data,value:2 });
        });
        //CARGAR LA LISTA DE MOTIVOS
        $http.post('../WAGSVPR_MOTI',
                JSON.stringify({
                    NUM_ACCI: 4
                }),
                { headers: { 'Content-Type': 'application/json' } })
        .success(function (data) {
            $('#cmbCOD_MOTI').dxSelectBox({ dataSource: data });
        });
        //CARGAR LA LISTA DE PROYECTOS
        $http.post('../WAGSVPR_PROY',
                JSON.stringify({
                    NUM_ACCI: 5
                }),
                { headers: { 'Content-Type': 'application/json' } })
        .success(function (data) {
            $('#cmbCOD_PROY').dxSelectBox({ dataSource: data });
        });
        //CARGAR LA LISTA DE SUCURSALES
        $http.post('../WAGSVPR_SUCU',
                JSON.stringify({
                    COD_SOCI_NEGO: obj.COD_SOCI_NEGO,
                    NUM_ACCI: 5
                }),
                { headers: { 'Content-Type': 'application/json' } })
        .success(function (data) {
            $('#cmbCOD_SUCU').dxSelectBox({ dataSource: data });
        });
        //CARGAR EL DETALLE DE LA COTIZACION
        $http.post('../WAGSVPR_DETA',
                JSON.stringify({
                    COD_COTI: obj.COD_COTI,
                    NUM_ACCI: 5
                }),
                { headers: { 'Content-Type': 'application/json' } })
        .success(function (data) {
            $('#gdvDetail').dxDataGrid({ dataSource: data });
        });
        //CARGAR LA INFORMACION DE LA COIZACION SELECCIONADA
        $http.post('../WAGSVPR_COTI_LIST',
                    JSON.stringify({
                        ALF_NUME_IDEN: obj.COD_COTI,
                        COD_TIPO_DOCU: 1,
                        NUM_ACCI: 8
                    }),
                    { headers: { 'Content-Type': 'application/json' } })
        .success(function (data) {
            $("#txtCOD_SOCI_NEGO").dxTextBox("instance").option("value",data[0].COD_SOCI_NEGO);
            $("#txtALF_NOMB").dxTextBox("instance").option("value",data[0].ALF_NOMB);
            $("#txtALF_DIRE_FISC").dxTextBox("instance").option("value",data[0].ALF_DIRE);
            $("#txtALF_TELE").dxTextBox("instance").option("value","");
            $("#txtALF_FAXX").dxTextBox("instance").option("value","");
            $("#txtALF_CONT").dxTextBox("instance").option("value",data[0].ALF_CONT);
            $("#cmbCOD_SUCU").dxSelectBox("instance").option("value",data[0].COD_SUCU);
            $("#txtNUM_DESC").dxTextBox("instance").option("value",data[0].NUM_DESC);
            $("#txtNUM_COTI").dxTextBox("instance").option("value",data[0].COD_COTI);
            $("#deFEC_REGI").dxDateBox("instance").option("value",data[0].FEC_REGI);
            $("#deFEC_DOCU").dxDateBox("instance").option("value",data[0].FEC_DOCU);
            $("#deFEC_VENC").dxDateBox("instance").option("value",data[0].FEC_VENC);
            $("#txtALF_ESTA").dxTextBox("instance").option("value",data[0].ALF_ESTA);
            $("#cmbCOD_MONE").dxSelectBox("instance").option("value",data[0].COD_MONE);
            $("#cmbCOD_PROY").dxSelectBox("instance").option("value", data[0].COD_PROY);
            $("#txtALF_ATEN").dxTextBox("instance").option("value",data[0].ALF_ATEN);
            $("#cmbCOD_MOTI").dxSelectBox("instance").option("value",data[0].COD_MOTI);
            $("#txtALF_COND_COME").dxTextArea("instance").option("value",data[0].ALF_COND_COME);
            $("#cmbCOD_EJEC_COME").dxSelectBox("instance").option("value",data[0].COD_EJEC_COME);
            $("#chkIGV").dxCheckBox("instance").option("value",data[0].IND_IMPU);
            $("#txtALF_OBSE").dxTextArea("instance").option("value",data[0].ALF_OBSE);
            $("#txtALF_SONN").dxTextBox("instance").option("value",data[0].ALF_TOTA);
            $("#txtNUM_SUBT").dxTextBox("instance").option("value",data[0].NUM_SUBT);
            $("#txtNUM_IGVV").dxTextBox("instance").option("value",data[0].NUM_IGVV);
            $("#txtNUM_TOTA").dxTextBox("instance").option("value",data[0].NUM_TOTA);
        });
    }
    $scope.ClearControl=function()
    {
        $("#txtCOD_SOCI_NEGO").dxTextBox("instance").option("value","");
        $("#txtALF_NOMB").dxTextBox("instance").option("value","");
        $("#txtALF_DIRE_FISC").dxTextBox("instance").option("value","");
        $("#txtALF_TELE").dxTextBox("instance").option("value","");
        $("#txtALF_FAXX").dxTextBox("instance").option("value","");
        $("#txtALF_CONT").dxTextBox("instance").option("value","");
        $("#txtALF_ATEN").dxTextBox("instance").option("value","");
        $("#cmbCOD_SUCU").dxSelectBox("instance").option("value", null);
        $("#cmbCOD_MONE").dxSelectBox("instance").option("value", 2);
        $("#cmbCOD_PROY").dxSelectBox("instance").option("value", null);
        $("#cmbCOD_MOTI").dxSelectBox("instance").option("value", "");
        $("#txtNUM_DESC").dxTextBox("instance").option("value","");
        $("#txtNUM_COTI").dxTextBox("instance").option("value","");
        $("#deFEC_REGI").dxDateBox("instance").option("value", new Date());
        $("#deFEC_DOCU").dxDateBox("instance").option("value",new Date());
        $("#deFEC_VENC").dxDateBox("instance").option("value", new Date());
        $("#txtALF_ESTA").dxTextBox("instance").option("value","");
        $("#gdvDetail").dxDataGrid("instance").option("dataSource",[]);
        $("#txtALF_OBSE").dxTextArea("instance").option("value", "");
        $("#txtALF_COND_COME").dxTextArea("instance").option("value", "");
        $("#txtNUM_SUBT").dxTextBox("instance").option("value",0);
        $("#txtNUM_IGVV").dxTextBox("instance").option("value",0);
        $("#txtNUM_TOTA").dxTextBox("instance").option("value",0);
        $("#txtALF_SONN").dxTextBox("instance").option("value","SON:");
        $("#chkIGV").dxCheckBox("instance").option("value",true);
        $("#cmbCOD_EJEC_COME").dxSelectBox("instance").option("value", null);
    }

    $scope.StateControl = function (vState) {
        $("#txtALF_NOMB").dxTextBox("instance").option("readOnly", vState);
        $("#cmbCOD_SUCU").dxSelectBox("instance").option("readOnly",vState);
        $("#cmbCOD_MONE").dxSelectBox("instance").option("readOnly", vState);
        $("#cmbCOD_PROY").dxSelectBox("instance").option("readOnly", vState);
        $("#txtNUM_DESC").dxTextBox("instance").option("readOnly",vState);
        $("#deFEC_DOCU").dxDateBox("instance").option("readOnly",vState);
        $("#deFEC_VENC").dxDateBox("instance").option("readOnly", vState);
        $("#txtALF_ATEN").dxTextBox("instance").option("readOnly",vState);
        $("#txtALF_OBSE").dxTextArea("instance").option("readOnly", vState);
        $("#cmbCOD_MOTI").dxSelectBox("instance").option("readOnly",vState);
        $("#txtALF_COND_COME").dxTextArea("instance").option("readOnly", vState);
        $("#chkIGV").dxCheckBox("instance").option("readOnly",vState);
        $("#cmbCOD_EJEC_COME").dxSelectBox("instance").option("readOnly",vState);
    }
    //-----------------------------------------------------------------------------------------------------//
    //BOTONES PARA LA PANTALLA DE COTIZACION
    //-----------------------------------------------------------------------------------------------------//
    $scope.buttonItems = [
        { toolbar: 'bottom', location: 'after', widget: 'button', options: { hint: 'Guardar', icon: 'save', width: 50, disabled: false, onClick: $scope.clickSave } },
        { toolbar: 'bottom', location: 'after', widget: 'button', options: { hint: 'Cerrar', icon: 'close', width: 50, disabled: false, onClick: $scope.clickClose } }
    ];

    $scope.clickClose = function () {
        $("#popupQuote").dxPopup("instance").hide();
    }
});