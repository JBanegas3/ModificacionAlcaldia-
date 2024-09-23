'use strict'

$(document).ready(function () {
    

    cargarInventario();
    

    interfazModales(2);
   
    $('#form1').on('submit', function (event) {
        event.preventDefault();
        llenacategorias();
        interfazModales(1);
    });

    $('#guardarCambios').on('click', function (event) {
        event.preventDefault();
        guardarcambios();
    });


    $('#cancelarCambios').on('click', function (event) {
        event.preventDefault(); 
        interfazModales(2);
    });

    

});


function cargarInventario() {
    $.ajax({
        url: 'inicio.aspx/ConsultaInventario',
        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
            
        
            var datos = data.d;
            
            mostrarDatos(datos);

        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}




//$('#data-table-buttons').DataTable({
//    "bAutoWidth": false,
//    "bProcessing": true,
//    "sAjaxSource": "inicio.aspx/ConsultaInventario",
//    "order": [],
//    "fnServerData": function (sSource, aoData, fnCallback) {
//        $.ajax({
//            "dataType": 'json',
//            "contentType": "application/json; charset=utf-8",
//            "type": "POST",
//            "url": sSource,
//            "data": "{}",
//            error: function () {
                
//            },
//            success: function (data) {
//                fnCallback(data.d);

//                var err = data.d.Error;
//                var msj = data.d.Mensaje;
//                if (err !== '')
//                    mensajeModalEnfasis(1, err);
//                else if (msj !== '') {
//                    if (tipo == 0) {
//                        mensajeModalEnfasis(3, msj);
//                    }
//                }

//            }
//        });
//    },
//    "aoColumnDefs": [
//        { "sWidth": "10%", "bSortable": false, "aTargets": [0] },
//        { "sWidth": "10%", "bSortable": false, "aTargets": [1] },
//        { "bVisible": false, "aTargets": [11, 12, 13, 14, 15, 16] }
//    ],
//    "aoColumns": [
//        { "sClass": "text-center" }, { "sClass": "text-center" }, null, null, null, null, null, null, null,
//        { "sClass": "text-end" }, null, null, null, null, null, null, null, null, null
//    ],
//    "sPaginationType": "full_numbers",
//    "fnRowCallback": function (nRow, aData, iDisplayIndex) {
//        $('td:eq(0) button[name="btnEdit"]', nRow).addClass('btn btn-warning btn-sm').html('<i class="fa fa-edit"></i> Editar');
//        $('td:eq(1) button[name="btnMover"]', nRow).addClass('btn btn-primary btn-sm').html('<i class="fa fa-share"></i> Mover');
//        $(nRow).attr("codctto", aData[1]);
//        $(nRow).attr("codproy", aData[2]);
//        $(nRow).attr("codfase", aData[3]);
//        return nRow;
//    },
//    "fnPreDrawCallback": function () {
        
//    },
//    "fnInitComplete": function () {
        
//        this.css('width', '');
        
//    }
//});






function mostrarDatos(info) {
    var tabla = $('#data-table-buttons tbody');
    tabla.empty(); // Limpiar la tabla antes de agregar nuevos datos
    var jsonObj = $.parseJSON(info);
    $.each(jsonObj.Datos, function (index, item) {
        var row = '<tr>' +
            '<td>' + item.codigoBarra + '</td>' +
            '<td>' + item.descripcion + '</td>' +
            '<td>' + item.categoria + '</td>' +
            '<td>' + item.unidad + '</td>' +
            '<td>' + item.existencia + '</td>' +
            '</tr>';
        tabla.append(row);
    });
    TableManageButtons.init();
}



var TableManageButtons = function () {
    return {
        //main function
        init: function () {
            handleDataTableButtons();
        }
    };
}();


function ajustarTabla(tabla) {
   tabla.DataTable({
        dom: '<"row"<"col-sm-5"B><"col-sm-7"fr>>t<"row"<"col-sm-5"i><"col-sm-7"p>>',
        buttons: [
            { extend: 'copy', className: 'btn-sm' },
            { extend: 'csv', className: 'btn-sm' },
            { extend: 'excel', className: 'btn-sm' },
            { extend: 'pdf', className: 'btn-sm' },
            { extend: 'print', className: 'btn-sm' }
        ],
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.6/i18n/es-MX.json',
        },
        retrieve: true,
        responsive: true

    });
}


var handleDataTableButtons = function () {
    $('#data-table-buttons').DataTable({
        dom: '<"row"<"col-sm-5"B><"col-sm-7"fr>>t<"row"<"col-sm-5"i><"col-sm-7"p>>',
        buttons: [
            { extend: 'copy', className: 'btn-sm' },
            { extend: 'csv', className: 'btn-sm' },
            { extend: 'excel', className: 'btn-sm' },
            { extend: 'pdf', className: 'btn-sm' },
            { extend: 'print', className: 'btn-sm' }
        ],
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.6/i18n/es-MX.json',
        },
        retrieve: true,
        responsive: true
      
    });
};





function guardarcambios() {
    var categoria = $('#categorias').val();
    var codbarra = $('#codbarra').val();
    var descripcion = $('#descripcion').val();
    var precio_venta = $('#precio_venta').val();


    $.ajax({
        url: 'inicio.aspx/guardaInventario',
        type: 'POST',
        cache: false,
        contentType: 'application/json',
        data: JSON.stringify({ categoria: categoria, codbarra: codbarra, descripcion: descripcion, precio_venta: precio_venta }),
        success: function (response) {

            var respuesta = response.d;
            if (respuesta.CodigoError == 1) {
                alert('Registros almacenados exitosamente');
                window.location.replace("inicio.aspx");
            }
            else {
                alert('Error al momento de almacenar los registros');
            }
            // Manejar la respuesta del servidor si es necesario
            
        },
        error: function (xhr, status, error) {
            // Manejar el error si ocurre
            console.error(error);
        },
        complete: function () {
            cargarInventario();
            interfazModales(2)
        }
    });
};


function agregarMascaraMoneda(input) {
        input.value = parseFloat(input.value.replace(/[^\d.-]/g, '')).toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
};


function interfazModales(idTipo) {
    if (idTipo == 1) {
        //Para bajar
        $('#consultaInventario').slideUp(200);
        $('#ingresarInventario').slideDown();
    }
    else {
        $('#consultaInventario').slideDown();
        $('#ingresarInventario').slideUp(200);
        
    }

}


function llenacategorias() {
    $.ajax({
        url: 'inicio.aspx/getCategorias',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        success: function (response) {
            // Limpiar el select antes de agregar las nuevas opciones
            
            $('#categorias').empty();
            
            var dat = response.d;
            var jsonObj = $.parseJSON(dat);
            // Iterar sobre los datos recibidos y agregar opciones al select
            $.each(jsonObj.Datos, function (index, categoria) {
             
                // Verificar si ya existe un optgroup con la misma etiqueta
                var optgroup = $('#categorias optgroup[label="' + categoria.TipoCategoria + '"]');
                if (optgroup.length === 0) {
                    // Si no existe, crear un nuevo optgroup
                    optgroup = $('<optgroup>', {
                        label: categoria.TipoCategoria
                    }).appendTo('#categorias');
                }
                // Agregar la opción al optgroup correspondiente
                optgroup.append($('<option>', {
                    value: categoria.CodCategoria,
                    text: categoria.DescCategoria
                }));
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al obtener las categorías:', error);
        }
    });

   

};






/*
function consultarInventario(tablas) {
    
    var tbody = $('#data-table-buttons tbody');
    $.ajax({
        url: 'inicio.aspx/ConsultaInventario',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        success: function (response) {
            // Limpiar la tabla antes de agregar nuevos datos
            tbody.empty();
           
            var dat = response.d;
            
            // Iterar sobre los datos recibidos y agregarlos a la tabla
            $.each(dat.Datos, function (index, item) {
                var row = '<tr class="odd gradeX">' +
                    '<td width="5%" class="f-s-100 text-inverse">' + item.codigoBarra + '</td>' +
                    '<td>' + item.descripcion + '</td>' +
                    '<td>' + item.categoria + '</td>' +
                    '<td>' + item.unidad + '</td>' +
                    '<td>' + item.existencia + '</td>' +
                    '</tr>';
                tbody.append(row);               
            });

            ajustarTabla(tablas);
       
            

            var loader = $('#page-loader');
            loader.toggleClass("fade");
            var cargando = $('#cargando');
            cargando.toggleClass("");
           
        },
        error: function (xhr, status, error) {
            console.error('Error al consultar el inventario:', error);
        }
    });
}
*/





















