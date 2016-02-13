var arrPageIns = [];
var defCOD_PAIS = '';
var app = angular.module('pper', ['ngRoute', 'dx']);
app.config(function ($provide, $routeProvider) {
    $provide.factory('$routeProvider', function () {
        return $routeProvider;
    });
}).run(function ($routeProvider, $http, $rootScope, $document) {

    $http({ method: 'POST', url: '../logoutaut', headers: { 'Content-Type': 'application/json' } })
              .success(function (data) {
                  if (data === "KO") {
                      $(location).attr('href', '../login.html');
                  }
                  else {
                      $routeProvider.when('/', {
                          templateUrl: 'default.html',
                          controller: 'defaultController'
                      }).otherwise({
                          redirectTo: '/'
                      });

                      $http({ method: 'POST', url: '../rols', headers: { 'Content-Type': 'application/json' } })
                      .success(function (data) {
                          console.log(data);
                          $.each(data, function (i, item) {
                              $routeProvider.when(item.ALF_WHEN_URLL, {
                                  templateUrl: item.ALF_TEMP_URLL,
                                  controller: item.ALF_CONT_URLL
                              });
                          });
                      });
                  }
              });

}).controller('LoginController', function ($scope, $http, $rootScope) {
    $scope.logout = function () {
        $http({ method: 'POST', url: '../logoutpper', headers: { 'Content-Type': 'application/json' } })
          .success(function (data) {
              $(location).attr('href', '../login.html');
          });
    };
}).controller('MainController', function ($scope, $http) {
    $http({ method: 'POST', url: '../rols', headers: { 'Content-Type': 'application/json' } })
    .success(function (data) {
        $('#gdvMain').dxDataGrid({ dataSource: data });
    });

    $scope.groupCellTemplate = function (groupCell, info) {
        $('<div>').html(info.text).css('font-style', 'bold').appendTo(groupCell);
    };

    $scope.customizeGroupText = function (columns) {
        $.each(columns, function (_, element) {
            element.groupCellTemplate = $scope.groupCellTemplate;
        });
    }

    $scope.cellTemplatehref = function (container, options) {
        $('<div><span class="dx-icon-vineta icon"></span><span>&nbsp;</span>' + options.data.ALF_DESC_MOST_FORM + '</div>')
            .on('dxclick', function () {
                $('#gdvMain').dxDataGrid('instance').selectRowsByIndexes(options.rowIndex);
                $(location).attr('href', options.data.ALF_DIRE_URLL_MVCC);
                Site.animation.sideMenuHide();
            }).appendTo(container);
    }
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

function IsNullOrWhiteSpace(value) {
    if (typeof value === 'undefined' || value === null || value === '') return true;
    return value.toString().replace(/\s/g, '').length < 1;
}

function monthDiff(d2, d1) {
    var months = (d2.getFullYear() - d1.getFullYear()) * 12;
    months -= d1.getMonth() + 1;
    months += d2.getMonth() + 1;
    return months <= 0 ? 0 : months;
}

Date.prototype.toShortDateString = function () {
    return isNaN(this) ? 'NaN' : [this.getDate() > 9 ? this.getDate() : '0' + this.getDate(), this.getMonth() > 8 ? this.getMonth() + 1 : '0' + (this.getMonth() + 1), this.getFullYear()].join('/')
}

Date.prototype.yyyymmdd = function () {
    var yyyy = this.getFullYear().toString();
    var mm = (this.getMonth() + 1).toString();
    var dd = this.getDate().toString();
    return yyyy + '-' + (mm[1] ? mm : "0" + mm[0]) + '-' + (dd[1] ? dd : "0" + dd[0]);
};

function arrSeparator(str, sep) {
    var output = '';
    for (var i = str.length; i > 0; i -= 2) {
        var ii = i - 1;
        if (output) {
            output = str.charAt(ii - 1) + str.charAt(ii) + sep + output;
        } else {
            output = str.charAt(ii - 1) + str.charAt(ii);
        }
    }
    return output;
};

function isNumber(n) {
    return (Object.prototype.toString.call(n) === '[object Number]' || Object.prototype.toString.call(n) === '[object String]') && !isNaN(parseFloat(n)) && isFinite(n.toString().replace(/^-/, ''));
};

function valCoordinate(coodinate, type) {
    if (type === 1) {
        if (isNumber(coodinate)) {
            if (parseFloat(coodinate) >= -90 && parseFloat(coodinate) <= 90) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }
    else {
        if (isNumber(coodinate)) {
            if (parseFloat(coodinate) >= -180 && parseFloat(coodinate) <= 180) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }
};

function IsEmail(email) {
    var reg = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    var val = reg.test(email);
    return val;
};