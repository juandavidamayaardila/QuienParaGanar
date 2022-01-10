// permite cargar lo eventos del los componentes cuando se usa updatepanels
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

function EndRequestHandler(sender, args) {
    console.log('prueba updatepanel');
    if (args.get_error() == undefined) {//Condicion si queremos manejar que hubo un error y no ejecutar nada
        iniciarScript1();
    }
}

$(document).ready(function () {

    iniciarScript1();
});

function iniciarScript1() {
    //Activa el calendario

    $('.datetime').datepicker({
        dateFormat: "dd/mm/yy",
        changeYear: true,
        changeMonth: true,
        yearRange: "1950:2120"
    });

    //$('.gridView-scroll').Scrollable();
    $('.gridView-scroll').Scrollable();
    
}