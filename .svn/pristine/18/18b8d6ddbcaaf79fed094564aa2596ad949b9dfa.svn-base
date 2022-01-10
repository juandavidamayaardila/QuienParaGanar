
// permite cargar lo eventos del los componentes cuando se usa updatepanels
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

function EndRequestHandler(sender, args) {
    console.log('prueba updatepanel');
    if (args.get_error() == undefined) {//Condicion si queremos manejar que hubo un error y no ejecutar nada
        iniciarScript();
    }
}


$(document).ready(function () {

    iniciarScript();
});

function iniciarScript() {
    $(".filtros").before("<div><table style='text-align:center;'><tr><td>Buscar</td><td><input type='text' id='texto' class='form-control'/></td><td><div id='flip'><i class='fa fa-th-list' style='text-align: center;' title='Ocultar columnas'></i></div><div id='list-checks'></div></td></tr></table> </div>");

    ///////////////// 
    //agregar una nueva columna con todo el texto 
    //contenido en las columnas de la grilla 
    // contains de Jquery es CaseSentive, por eso a minúscula
    $(".filtrar  tr:has(td)").each(function () {
        //console.log("filtar");

        var t = $(this).text().toLowerCase();
        $("<td class='indexColumn'></td>")
            .hide().text(t).appendTo(this);
    });

    //Agregar el comportamiento al texto (se selecciona por el ID)
    $("#texto").keyup(function () {
        //console.log("texto");

        var s = $(this).val().toLowerCase().split(" ");
        $(".filtrar tr:hidden").show();
        if (s != "") {
            $.each(s, function () {
                $(".filtrar tr:visible .indexColumn:not(:contains('" + this + "'))").parent().hide();
            });
        }
    });

    // ocultar o mostrar la lista de checks 
    $("#flip").click(function (e) {

        $("#list-checks").slideToggle("slow");

    });

    var columnas = $(".hide-column tr th").length;

    // se crean los checkbox con los nombres de las columnas
    for (var i = 0; i < columnas; i++) {
        $("#list-checks").append('<div class="check"><input type="checkbox"  checked="true" onChange="ocultar(this,' + i + ')" name="titulos" value="' + i + '"> <span>' + $('.hide-column tr th:eq(' + i + ')').html() + '</span></div>');
    }
}

function ocultar(checbox, pos) {

    fila = $('.hide-column tr');

    // mostrar u ocultar las cabezeras de la tabla
    $('.hide-column tr:eq(0)').find('th:eq(' + pos + ')').toggle();


    //mostramos u ocultamos las celdas de la columna seleccionada
    for (i = 1; i < fila.length; i++) {
        $('.hide-column tr:eq(' + i + ')').find('td:eq(' + pos + ')').toggle();
    }

}

