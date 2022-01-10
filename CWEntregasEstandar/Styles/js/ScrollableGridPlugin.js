
//----------------------------------------------------------------------

(function ($) {
    $.fn.Scrollable = function (options) {
        var defaults = {
            ScrollHeight: 300,
            Width: 0
        };

        var options = $.extend(defaults, options);
        return this.each(function () {
            var grid = $(this).get(0);
            var gridWidth = 0;
            var gridHeight = grid.offsetHeight;
            var headerCellWidths = new Array();
            var padding = 0;

            for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;

            }

            // obtener el padding de las celdas para sumarlo al tamaño de la tabla
            padding = parseInt($('th').css('padding-left')) * 2;// padding left y right

            padding = padding * headerCellWidths.length;


            //---------------------------------------

            grid.parentNode.appendChild(document.createElement("div"));
            var parentDiv = grid.parentNode;

            var table = document.createElement("table");


            for (i = 0; i < grid.attributes.length; i++) {
                if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                    table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                }
            }

            table.style.cssText = grid.style.cssText;
            table.appendChild(document.createElement("tbody"));

            table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
            var cells = table.getElementsByTagName("TH");

            var gridRow = grid.getElementsByTagName("TR")[0];

            // poner el tamaño de las celdas igual, se verifica la celda del encabezado o del cuerpo que tenga 
            // mayor tamaño y se le asigna a la demenor tamaño,
            for (var i = 0; i < cells.length; i++) {

                var width;
                if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                    width = headerCellWidths[i];
                }
                else {
                    width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                }

                if (width > 250) {
                    width = 250;// tamaño maximo de las celdas (th,td)
                }

                cells[i].style.width = parseInt(width) + "px";
                gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width) + "px";

                //whidth de la tabla
                gridWidth = gridWidth + width;

            }//for

            gridWidth = gridWidth + padding;
            table.style.width = gridWidth + "px";


            var dummyHeader = document.createElement("div");
            dummyHeader.appendChild(table);
            parentDiv.appendChild(dummyHeader);
            if (options.Width > 0) {
                gridWidth = options.Width;
            }


            var scrollableDiv = document.createElement("div");
            if (parseInt(gridHeight) > options.ScrollHeight) {
                gridWidth = parseInt(gridWidth) + 17;
            }
            scrollableDiv.style.cssText = "overflow:auto;height:" + options.ScrollHeight + "px;width:" + gridWidth + "px; margin: auto;";
            scrollableDiv.appendChild(grid);
            parentDiv.appendChild(scrollableDiv);

        });
    };
})(jQuery);


