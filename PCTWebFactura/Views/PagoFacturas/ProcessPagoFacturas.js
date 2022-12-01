
$(document).ready(function () {
    var listFacturas = fnCargarFacturas("/PagoFacturas/cargarFacturasAPI");
    console.log(listFacturas);
    tblFacturas.setData(listFacturas);
});



var tblFacturas = new Tabulator("#tFormaPagoIngresosFacturas", {
    width: "400",
    height: "300",
    pagination: "local", //enable remote pagination
    selectable: 1,
    rowFormatter: function (row) {
        //var cell = row.getCell("VALOR");
        //cell.getElement().style.backgroundColor = "#FFFFFF";
    },
    movableRows: false,
    tooltips: true,
    addRowPos: "top",
    paginationButtonCount: 0,
    paginationSize: 25,
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
            field: "FECHA_REGISTRO",
            headerSort: false,
            align: "center",
            width: 120
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
        console.log(datos);
        console.log(rows);
        if (datos.length > 0) {
            
        }
    },
});

