'use strict'

window.addEventListener('load', function () {

    const salir = document.getElementById('salirPlataforma');
    
    salir.addEventListener('click', function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            url: 'inicio.aspx/CierreSesion',
            cache: false,
            contentType: "application/json;",
            dataType: "json",
            data: JSON.stringify({}),
            error: function (jqXHR, textStatus, errorThrown) {
            },
            success: function (data) {

                window.location.replace("default.aspx");

            }



        });
    });

  
   



});
