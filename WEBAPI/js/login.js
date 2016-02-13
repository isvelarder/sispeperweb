$(window).load(function () {
    $(document).ready(function () {
        $(window).resize(function () {
            $('.alpha').css({
                position: 'absolute',
                display: 'inline',
                left: ($(window).width() - $('.alpha').outerWidth()) / 2,
                top: ($(window).height() - $('.alpha').outerHeight()) / 2
            });
        });
        $(window).resize();
    });
});

$(document).ready(function () {
    $('#txtUser')
        .dxTextBox({ value: '', placeholder: 'USUARIO' })
        .dxValidator({
            validationRules: [{
                type: 'required',
                message: 'Usuario es requerido.'
            }],
            validationGroup: 'ValGroup'
        });
    $('#txtPassword').dxTextBox({ value: '', placeholder: 'CONTRASEÑA', mode: 'password' })
            .dxValidator({
                validationRules: [{
                    type: 'required',
                    message: 'Contraseña es requerida.'
                }],
                validationGroup: 'ValGroup'
            });

    $('#txtCaptcha').dxTextBox({ value: '', placeholder: 'CAPTCHA' })
        .dxValidator({
            validationRules: [{
                type: 'required',
                message: 'Captcha es requerido.'
            }],
            validationGroup: 'ValGroup'
        });

    $('#loadContainer').dxLoadPanel({ message: 'Iniciando Sesión...' });
});

function MessageNotify(MessageText, MessageIcon) {
    $('#toastContainer').dxToast({
        message: MessageText,
        animation: {
            show: { type: 'pop', from: { opacity: 1, scale: 0 }, to: { scale: 1 } },
            hide: { type: 'pop', from: { scale: 1 }, to: { scale: 0 } }
        },
        type: MessageIcon,
        displayTime: 4000
    });
    $('#toastContainer').dxToast('instance').show();
}

var iqApp = angular.module('pper', ['dx']);
iqApp.controller('SessionController', function ($scope, $http) {
    $scope.Get_Login = function () {
        var result = DevExpress.validationEngine.validateGroup('ValGroup');
        if (result.isValid) {
            $('#loadContainer').dxLoadPanel('instance').show();
            var txtCaptcha = $('#txtCaptcha').dxTextBox('instance');
            var pars = JSON.stringify(txtCaptcha.option('value'));
            $http({
                method: 'POST',
                url: 'SVPR_CAPC',
                data: pars,
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                if (data === '0') {
                    $('#loadContainer').dxLoadPanel('instance').hide();
                    MessageNotify('Captcha incorrecto.', 'warning');
                }
                else {
                    var txtUser = $('#txtUser').dxTextBox('instance');
                    var txtPassword = $('#txtPassword').dxTextBox('instance');
                    var objl = { COD_USUA: txtUser.option('value'), ALF_PASS: txtPassword.option('value'), ALF_CAPT: txtCaptcha.option('value') };
                    pars = '[' + JSON.stringify(objl) + ']';
                    $http({
                        method: 'POST',
                        url: 'SVPR_USUA',
                        data: JSON.stringify(objl),
                        headers: { 'Content-Type': 'application/json' }
                    }).success(function (data) {
                        if (data.IND_ACTI === 0) {
                            $('#loadContainer').dxLoadPanel('instance').hide();
                            MessageNotify('Acceso denegado, verificar usuario y contraseña.', 'warning');
                        }
                        else {
                            $(location).attr('href', 'Views/MainBack.html');
                        }
                    }).error(function (data) {
                        $('#loadContainer').dxLoadPanel('instance').hide();
                        MessageNotify('Error interno, informar al administrador del sistema.', 'error');
                    });
                }
            }).error(function (data) {
                $('#loadContainer').dxLoadPanel('instance').hide();
                MessageNotify('Error interno, informar al administrador del sistema.', 'error');
            });
        }
    }
}).controller('CaptchaController', function ($scope, $http) {
    $scope.Get_Captcha = function () {
        document.getElementById("imgCaptcha").src = "Images/captchaloader.gif";
        $http({
            method: 'POST',
            url: 'xDrp87Hytgvrdsssf43f',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            document.getElementById("imgCaptcha").src = "data:image/png;base64," + data;
        }).error(function (data) {
            MessageNotify('Error interno, informar al administrador del sistema.', 'error');
        });
    }

    $scope.Get_Captcha();
});
