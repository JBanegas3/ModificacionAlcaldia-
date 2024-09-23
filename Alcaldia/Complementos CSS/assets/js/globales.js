function notificarEnfasis(enfasis, mensaje, tiempo) {
    var titulo = 'Mensaje del Sistema';
    var clase = 'info';

    if (tiempo === undefined)
        tiempo = 4500;

    if (enfasis === 1) {
        titulo = 'Error';
        clase = 'error';
    }
    else if (enfasis === 2) {
        titulo = 'Éxito';
        clase = 'success';
    }
    else if (enfasis === 3) {
        titulo = 'Atención';
        clase = 'info';
    }
    else if (enfasis === 4) {
        titulo = 'Advertencia';
        clase = 'warning';
    }

    



    Swal.fire({
        position: 'top',
        icon: clase,
        title: titulo,
        text: mensaje,
        showConfirmButton: false,
        timer: tiempo
    });
}

//enfasis (1: Error, 2: Éxito, 3: Atención, 4: Advertencia)
function mensajeModalEnfasis(enfasis, mensaje) {
    var titulo = 'Mensaje del Sistema';
    var clase = 'info';
    var claseBtn = 'default';
    if (enfasis === 1) {
        titulo = 'Error';
        clase = 'error';
        claseBtn = 'btn-danger';
    }
    else if (enfasis === 2) {
        titulo = 'Éxito';
        clase = 'success';
        claseBtn = 'btn-success';
    }
    else if (enfasis === 3) {
        titulo = 'Atención';
        clase = 'info';
        claseBtn = 'btn-info';
    }
    else if (enfasis === 4) {
        titulo = 'Advertencia';
        clase = 'warning';
        claseBtn = 'btn-warning';
    }
    swal({
        position: 'top',
        title: titulo,
        text: mensaje,
        icon: clase,
        showConfirmButton: false,
        timer: 1000
        
    });
}