

function load() {



    $.ajax({
        type: "POST",
        url: 'LoadData.ashx',
        data: null,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (Terr) {
            $("#t01 contenido").html("");
            for (var i = 0; i < Terr.length; i++) {
                var item = "<tr id=" + Terr[i].id+">"
                    + "<td>" + Terr[i].id + "</td>"
                    + "<td>" + Terr[i].razonSocial + "</td>"
                    + "<td>" + Terr[i].direccion + "</td>"
                    + "<td><button type='button'  class='btn iconcss' onclick='EditCliente(" + Terr[i].id + ")'><img src='https://img.icons8.com/android/24/000000/edit.png'/></button><button type='button'  class='btn iconcss' onclick='deleteCliente(" + Terr[i].id +")'><img src='https://img.icons8.com/material-rounded/24/000000/erase.png'/></button></td>"
                    + "</tr>";
                $('#t01').append(item);

            }

            $('#t01').show();
        },
    });
   
}


