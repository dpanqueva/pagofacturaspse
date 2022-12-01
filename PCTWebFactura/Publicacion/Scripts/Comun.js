//  var basePath = "";
 var basePath = "/PCTWEBFacturaDotNet";

var CodigofacturaSeleccionado;

fnCheckTransaction = function (idTransaccion) {
    var respuesta;
    $.ajax({
        async: false,
        type: 'GET',
        url: 'https://Sandbox.wompi.co/v1/transactions/' + idTransaccion,
        dataType: 'JSON',
        success: function (data) {
            console.log(data);
            
            actualizarEstadoWompi(data);
            if (data.data.status == "APPROVED") {

                const formatterPeso = new Intl.NumberFormat('es-CO', {
                    style: 'currency',
                    currency: 'COP',
                    minimumFractionDigits: 0
                })
                var montoPagado = data.data.amount_in_cents.toString().substring(0, data.data.amount_in_cents.toString().length - 1);
                montoPagado = montoPagado.substring(0, montoPagado.length - 1);
                Swal.fire(
                    'Perfecto!',
                    'Hemos recibido correctamente su pago de la factura ' + data.data.reference + ' por un valor de ' + formatterPeso.format(montoPagado),
                    'success'
                );
            } else if (data.data.status == "DECLINED") {
                Swal.fire(
                    'Advertencia!',
                    'Pago declinado intenta nuevamente',
                    'warning'
                )
            }
            else {
                Swal.fire(
                    'Error!',
                    'Su pago no se registró correctamente, por favor intente nuevamente',
                    'error'
                )
            }

             fnCargarFacturas("/PagoFacturas/cargarFacturasAPI?idPago=''", false);

            
        },
        error: function (response) {
            vex.dialog.alert(response.message);
            debugger;
        }
    });
    return respuesta;
}

fnCheckTransactionZpagos = function (idTransaccion) {
    var respuesta;
    $.ajax({
        async: false,
        type: 'GET',
        url: basePath+'/PagoFacturas/ValidacionPagoZonaPagos?idTransaccion=' + idTransaccion,
        success: function (data) {
            console.log(data);
            /*if (data.data.status == "APPROVED") {

                const formatterPeso = new Intl.NumberFormat('es-CO', {
                    style: 'currency',
                    currency: 'COP',
                    minimumFractionDigits: 0
                })
                var montoPagado = data.data.amount_in_cents.toString().substring(0, data.data.amount_in_cents.toString().length - 1);
                montoPagado = montoPagado.substring(0, montoPagado.length - 1);
                Swal.fire(
                    'Perfecto!',
                    'Hemos recibido correctamente su pago de la factura' + data.data.reference + ' por un valor de ' + formatterPeso.format(montoPagado),
                    'success'
                )
            } else if (data.data.status == "DECLINED") {
                Swal.fire(
                    'Advertencia!',
                    'Pago declinado intenta nuevamente',
                    'warning'
                )
            }
            else {
                Swal.fire(
                    'Error!',
                    'Su pago no se registró correctamente, por favor intente nuevamente',
                    'error'
                )
            }*/
        },
        error: function (response) {
            vex.dialog.alert(response.message);
            debugger;
        }
    });
    return respuesta;
}


var btnPagoWompi;
var requestIdPlaceToPay;
var btnSelected;
var itemSelected = null;
var nit = "";
var control;
var tblFacturas;
var btnModalPagar;
dataModal = function (item) {
    btnSelected = item;
    if (itemSelected != null) {
        var modal = document.getElementById("btnModal");
        modal.click();
    } else {
        Swal.fire(
            'Informacion!',
            'Debe seleccionar una factura primero',
            'warning'
        )
    }
}

$(document).ready(function () {
    let searchParams = new URLSearchParams(window.location.search);
    if (searchParams.get('id') != null) {
        control = true;
        fnCheckTransaction(searchParams.get('id'));
    } else {
      
       fnCargarFacturas("/PagoFacturas/cargarFacturasAPI?idPago=" + searchParams.get('id_pago'), true);

        

    }

     btnModalPagar = document.getElementById("btnPagarModal");
    btnModalPagar.addEventListener("click", function () {

        var email = document.getElementById("emailUser").value;
        var telefono = document.getElementById("telefonoUser").value;
        var flag = true;
        var mensaje = "";
        if (email == "") {
            flag = false;
            mensaje = "Debe digitar un Email";
        } else if (telefono == 0) {
            flag = false;
            mensaje = "Debe digitar un telefono";
        }
        if (flag) {
            itemSelected.BTN_SELECTED = btnSelected;
            fnValidationFactura("/PagoFacturas/PagarValidation", itemSelected);
        } else {
            Swal.fire(
                'Informacion!',
                mensaje,
                'warning'
            )
        }


    }, false);

     tblFacturas = new Tabulator("#tFormaPagoIngresosFacturas", {
        width: "400",
        height: "300",
        pagination: "local", //enable remote pagination
        selectable: 1,
        placeholder: "No se encontraron facturas pendientes por pagar",
        layout: "fitData",
        rowFormatter: function (row) {
            //var cell = row.getCell("VALOR");
            //cell.getElement().style.backgroundColor = "#FFFFFF";
        },
        movableRows: false,
        tooltips: true,
        addRowPos: "top",
        paginationButtonCount: 0,
        paginationSize: 20,
        paginationSizeSelector: true,
        movableColumns: false,
        resizableRows: false,
        columns: [

            {
                title: "Vigencia",
                field: "VIGENCIA",
                headerSort: false,
                align: "center",
                width: 100
            },
            {
                title: "N Factura",
                field: "COD_FACTURA",
                headerSort: false,
                align: "center",
                width: 100
            },
            {
                title: "N Referencia",
                field: "ID_MFACTURA",
                headerSort: false,
                align: "center",
                width: 100
            },

            {
                title: "Referencia",
                field: "REFERENCIA",
                headerSort: false,
                align: "center",
                width: 250
            },
            {
                title: "Fecha Corte",
                field: "FEC_ACTUAL",
                headerSort: false,
                align: "center",
                width: 120,
                formatter: "datetime", formatterParams: {
                    inputFormat: "YYYY-MM-DD",
                    outputFormat: "DD/MM/YYYY",
                    invalidPlaceholder: "(invalid date)",
                }
            },
            {
                title: "Recargos",
                field: "VAL_RECARGOFAC",
                headerSort: false,
                align: "right",
                formatter: "money",
                width: 100,
                formatterParams: {
                    decimal: ".",
                    thousand: ",",
                    symbol: "$",
                    align: "right",
                    precision: 2
                }

            },
            {
                title: "Descuentos",
                field: "VAL_DESCUENTOFAC",
                headerSort: false,
                align: "right",
                formatter: "money",
                width: 100,
                formatterParams: {
                    decimal: ".",
                    thousand: ",",
                    symbol: "$",
                    align: "right",
                    precision: 2
                }

            },
            {
                title: "Valor Interés",
                field: "VAL_INTERESCOBRAR",
                headerSort: false,
                align: "right",
                formatter: "money",
                width: 100,
                formatterParams: {
                    decimal: ".",
                    thousand: ",",
                    symbol: "$",
                    align: "right",
                    precision: 2
                }

            },
            {
                title: "Valor Capital",
                field: "VAL_CUENTASCOBRAR",
                headerSort: false,
                align: "right",
                formatter: "money",
                width: 100,
                formatterParams: {
                    decimal: ".",
                    thousand: ",",
                    symbol: "$",
                    align: "right",
                    precision: 2
                }

            },
            {
                title: "Total",
                field: "VAL_TOTALFAC",
                headerSort: false,
                align: "right",
                formatter: "money",
                width: 100,
                formatterParams: {
                    decimal: ".",
                    thousand: ",",
                    symbol: "$",
                    align: "right",
                    precision: 2
                }

            }
        ],
        rowSelectionChanged: function (datos, rows) {
            if (datos.length > 0) {
                document.getElementById("botonWompi").disabled = false;
                document.getElementById("botonZpagos").disabled = false;
                document.getElementById("botonPlace").disabled = false;
                console.log(datos);
                itemSelected = datos[0];
                fnDetallarFactura(datos[0]);
                CodigofacturaSeleccionado = datos[0].COD_FACTURA;

            }
        },
    });
    /*btnPagoWompi = document.getElementById("btnPagoWompi");
    btnPagoWompi.addEventListener("click", function () {
        
        fnPayWompi("/PagoFacturas/PagarWompi", itemSelected);
    }, false);*/
});


//FUNCTION PLACE TO PAY
fnPagoPlaceToPay = function (obj) {
    $.ajax({
        async: false,
        type: 'POST',
        url: basePath +'/PagoFacturas/ConsumoPlaceToPay',
        data: obj,
        dataType: 'JSON',
        success: function (data) {
            console.log(data);
            if (data.Codigo == 1) {
                requestIdPlaceToPay = data.Object.requestId;
                window.location.href = data.Object.processUrl;

            } else {
                Swal.fire(
                    'Error!',
                    data.Mensaje,
                    'error'
                )
            }
        },
        error: function (response) {
            vex.dialog.alert(response.message);
            debugger;
        }
    });
}
// FUNCTION PAGO ZPAGOS
fnPagoZpagos = function (obj) {
    $.ajax({
        async: false,
        type: 'POST',
        url: basePath+ '/PagoFacturas/ConsumoZpagos',
        data: obj,
        dataType: 'JSON',
        success: function (data) {
            if (data.Codigo == 1) {
                window.location.href = data.Ruta;

            } else {
                Swal.fire(
                    'Error!',
                    data.Mensaje,
                    'error'
                )
            }
        },
        error: function (response) {
            vex.dialog.alert(response.message);
            debugger;
        }
    });

}

actualizarEstadoWompi = function (obj2){
    var obj = new Object();
    obj.idpago = obj2.data.reference;
    obj.status = obj2.data.status;
    obj.valor = obj2.data.amount_in_cents.toString().substring(0, obj2.data.amount_in_cents.toString().length - 2);
    console.log(obj.valor);
    obj.fepago = obj2.data.created_at;
    obj.idrequeswompi = obj2.data.id;
    obj.payment = obj2.data.payment_method_type;
    $.ajax({
        async: false,
        type: 'POST',
        url: basePath+'/PagoFacturas/ActualizarEstadoWompi',
        data: obj,
        dataType: 'JSON',
        success: function (data) {
            console.log(data);
            if (data.Codigo == 1) {
                console.log(data);

            } else {
                Swal.fire(
                    'Error!',
                    data.Mensaje,
                    'error'
                )
            }
        },
        error: function (response) {
            vex.dialog.alert(response.message);
            debugger;
        }
    });
}
fnPagoWompi = function (obj) {
    $.ajax({
        async: false,
        type: 'POST',
        url: basePath+ '/PagoFacturas/ConsumoWompi',
        data: obj,
        dataType: 'JSON',
        success: function (data) {
            if (data.Codigo == 1) {
                document.getElementById("txtEmailPagador").setAttribute('value', document.getElementById("emailUser").value);
                document.getElementById("formWompi").submit();

            } else {
                Swal.fire(
                    'Error!',
                    data.Mensaje,
                    'error'
                )
            }
        },
        error: function (response) {
            vex.dialog.alert(response.message);
            debugger;
        }
    });

}



// FUNCTION VALIDATION FACTURA
fnValidationFactura = function (UrlConsulta, obj) {
    var respuesta;
    $.ajax({
        async: false,
        type: 'POST',
        url: basePath+UrlConsulta,
        data: obj,
        dataType: 'JSON',
        success: function (data) {
            if (data.Codigo == 1) {
                $.ajax({
                    async: false,
                    type: 'POST',
                    url: basePath+'/PagoFacturas/IniciarTransaccion',
                    data: obj,
                    dataType: 'JSON',
                    success: function (data) {
                        if (data.Codigo == 1) {
                            var obj = new Object();
                            obj.email = document.getElementById("emailUser").value;
                            obj.telefono = document.getElementById("telefonoUser").value;
                            obj.itemSelected = itemSelected;
                            if (btnSelected == "Zpagos") {
                                fnPagoZpagos(obj);
                            } else if (btnSelected == "PlaceToPay") {
                                fnPagoPlaceToPay(obj);
                            } else if (btnSelected == "Wompi") {
                                fnPagoWompi(obj);
                            }
                        } else {
                            Swal.fire(
                                'Advertencia!',
                                data.Mensaje,
                                'warning'
                            )
                        }
                    },
                    error: function (response) {
                        vex.dialog.alert(response.message);
                        debugger;
                    }
                });
            } else {
                Swal.fire(
                    'Advertencia!',
                    'Comuníquese con la entidad, Se deben ajustar ' + data.Mensaje,
                    'warning'
                )
            }
        },
        error: function (response) {
            vex.dialog.alert(response.message);
            debugger;
        }
    });
    return respuesta;
}
// AJAX para traer el listado de facturas
fnCargarFacturas = function (UrlConsulta, showLoading) {
    var respuesta;
    if (showLoading) {
        Swal.fire('Espere...')
        Swal.showLoading();
    }
    
    $.ajax({
        async: true,
        type: 'POST',
        url: basePath+UrlConsulta,
        dataType: 'JSON',
        success: function (data) {
            if (data.Codigo == 1) {
                console.log(data);
                
                nit = data.Mensaje;
                if (!control) {
                    Swal.close();
                }
                if (data.Data != null && data.Data.length != 0) {
                    tblFacturas.setData(data.Data);
                } else {
                    Swal.close();
                    Swal.fire(
                        'Informacion!',
                        'Usted no tiene facturas pendientes por pagar',
                        'warning'
                    )
                }
               
                data.codPasarela.forEach((element) => {
                    if (element == 1) {
                        var theDivW = document.getElementById("divWompi");
                        var classContentW = theDivW.className;
                        theDivW.className = classContentW.replace("hiddenDiv", "").trim();
                    } else if (element == 2) {
                        var theDivP = document.getElementById("divPlacetoPay");
                        var classContent = theDivP.className;
                        theDivP.className = classContent.replace("hiddenDiv", "").trim();
                    } else if (element == 3) {
                        var theDiv = document.getElementById("divZpagos");
                        var classContent = theDiv.className;
                        theDiv.className = classContent.replace("hiddenDiv", "").trim();
                    }
                });
                $.ajax({
                    async: true,
                    type: 'POST',
                    url: basePath + '/PagoFacturas/ActualizarEstadosFacturas',
                    dataType: 'JSON',
                    success: function (data) {
                        if (data.Codigo == 1) {
                            control = data.ActualizoEstadoFacturas;
                            if (data.ActualizoEstadoFacturas) {
                                if (data.Data != null && data.Data.length != 0) {
                                    tblFacturas.setData(data.Data);
                                }
                                Swal.fire(
                                    'Perfecto!',
                                    'Se ha registado el siguiente pago correctamente: <br> ' + data.FacturaActualizadaMessage,
                                    'success'
                                )

                            }
                        } else {
                            Swal.close();
                            Swal.fire(
                                'Error!',
                                data.Mensaje,
                                'error'
                            )
                            return null;
                        }
                    }
                });
               
            } else {
                Swal.close();
                Swal.fire(
                    'Error!',
                    data.Mensaje,
                    'error'
                )
                return null;
            }


        },
        error: function (response) {
            vex.dialog.alert(response.message);
            debugger;
        }
    });
    return respuesta;
}
// FUNTION PAY WOMPI
fnPayWompi = function (UrlConsulta, obj) {
    var respuesta;
    $.ajax({
        async: false,
        type: 'POST',
        url: basePath+'',
        data: obj,
        dataType: 'JSON',
        success: function (data) {
            if (data.Codigo == 1) {
                console.log("OKOK");
            } else {
                Swal.fire(
                    'Error!',
                    data.Mensaje,
                    'error'
                )
            }
        },
        error: function (response) {
            vex.dialog.alert(response.message);
            debugger;
        }
    });
    return respuesta;
}
// FUNCTION para detallar la factura seleccionada
fnDetallarFactura = function (Datos = {}) {

    $("#txtVigencia").text(Datos.VIGENCIA);
    $("#txtEstado").text(Datos.ESTADO_FACTURA);
    $("#txtImpreso").text(Datos.IMPRESO);
    $("#txtNFactura").text(Datos.COD_FACTURA);
    $("#txtTipoFactura").text(Datos.TIPO_FACTURA);
    $("#txtFeVencimiento").text(fnCambiarFormatoFecha(Datos.FECHA_LIMITE).replace(/^(\d{4})-(\d{2})-(\d{2})$/g, '$3/$2/$1'));
    $("#txtFeRegistro").text(fnCambiarFormatoFecha(Datos.FECHA_REGISTRO).replace(/^(\d{4})-(\d{2})-(\d{2})$/g, '$3/$2/$1'));
    $("#txtDesde").text(fnCambiarFormatoFecha(Datos.FECHA_FACTURADESDE).replace(/^(\d{4})-(\d{2})-(\d{2})$/g, '$3/$2/$1'));
    $("#txtNCot").text(Datos.COD_COT);
    $("#txtHasta").text(fnCambiarFormatoFecha(Datos.FECHA_FACTURA).replace(/^(\d{4})-(\d{2})-(\d{2})$/g, '$3/$2/$1'));
    $("#txtCodVendedor").text(Datos.COD_VENDEDOR);
    $("#txtCodTasa").text(Datos.COD_TASA);
    $("#txtObservaciones").text(Datos.OBSERVAC);
    console.log(Datos.TOTAL_PAGO);
    document.getElementById("txtValorTotal").setAttribute('value', Datos.VAL_TOTALFAC + "00");
    document.getElementById("txtReferencia").setAttribute('value', Datos.ID_MFACTURA);
    document.getElementById("txtNombrePagador").setAttribute('value', Datos.NOMBRE);
    document.getElementById("txtTipoDocPagador").setAttribute('value', "CC");
    /*$("#txtValorTotal").text("");
    $("#txtReferencia").text("");
    $("#txtEmailPagador").text("");
    $("#txtNombrePagador").text("");
    $("#txtTelefonoPagador").text("");
    $("#txtTipoDocPagador").text("CC");*/
}
// FUNCTION para cambiar formato de fecha 
fnCambiarFormatoFecha = function (fecha) {
    var fechaCompr = new Date(fecha);
    fechaCompr.setMinutes(fechaCompr.getMinutes() - fechaCompr.getTimezoneOffset());
    fechaCompr = fechaCompr.toJSON().slice(0, 10);
    return fechaCompr;
}


GenerarFactura = function () {
    if (CodigofacturaSeleccionado != null && CodigofacturaSeleccionado != "") {
       /* $.ajax({
            async: false,
            type: 'POST',
            url: basePath + '/PagoFacturas/GenerarRptFactura',
            data: itemSelected,
            dataType: 'JSON',
            success: function (data) {
                console.log(data);
            },
            error: function (response) {
                vex.dialog.alert(response.message);
                debugger;
            }
        });*/
        $.redirect(basePath + '/PagoFacturas/GenerarRptFactura', { codFactura: CodigofacturaSeleccionado });
    } else {
        Swal.fire(
            'Advertencia!',
            'Debe seleccionar una factura primero',
            'warning'
        )
    }
    
   
}
