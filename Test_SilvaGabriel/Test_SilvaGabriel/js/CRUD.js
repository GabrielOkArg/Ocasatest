
function AddCliente(e) {
  
    var id_ = document.getElementById("id");
    var razon_ = document.getElementById("razon");
    var direccion_ = document.getElementById("direccion");

    var id = id_.value;
    var razon = razon_.value;
    var direccion = direccion_.value;
    $.ajax({
        type: "POST",
        url: 'NewCliente.ashx',
        data: {id,razon,direccion},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function ()  {


           
           
        },

    });

    document.getElementById("id").value = "";
    document.getElementById("razon").value = "";
    document.getElementById("direccion").value = "";
    document.getElementById("contenido").innerHTML = "";
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
                var item = "<tr id=" + Terr[i].id + ">"
                    + "<td>" + Terr[i].id + "</td>"
                    + "<td>" + Terr[i].razonSocial + "</td>"
                    + "<td>" + Terr[i].direccion + "</td>"
                    + "<td><button type='button'  class='btn iconcss' onclick='EditCliente(" + Terr[i].id + ")'><img src='https://img.icons8.com/android/24/000000/edit.png'/></button><button type='button'  class='btn iconcss' onclick='deleteCliente(" + Terr[i].id + ")'><img src='https://img.icons8.com/material-rounded/24/000000/erase.png'/></button></td>"
                    + "</tr>";
                $('#t01').append(item);

            }

            $('#t01').show();
        },
    });
   
}

function savachanges(e) {
    var id_ = document.getElementById("id_text");
    var razon_ = document.getElementById("razon_text");
    var direccion_ = document.getElementById("direccion_text");
    var id = id_.value;
    var razon = razon_.value;
    var direccion = direccion_.value;
    $.ajax({
        type: "POST",
        url: 'EditCliente.ashx',
        data: { id, razon, direccion },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (Terr) {
            console.log(Terr);

        },
    });
}

function EditCliente(id) {
    var tabla = document.getElementById(id);
    var id = tabla.cells[0].innerText
    var razon = tabla.cells[1].innerText;
    var direccion = tabla.cells[2].innerText;
    document.getElementById("formularioedicion").style.display = "block";
    document.getElementById("id_text").value = id;
    document.getElementById("razon_text").value = razon;
    document.getElementById("direccion_text").value = direccion;
}

function closeDialog() {
    document.getElementById("formularioedicion").style.display = "none";
}

function deleteCliente(id) {
    var result = window.confirm("Se va a eliminar un cliente esta seguro?")
    var tabla = document.getElementById(id);
    var id = tabla.cells[0].innerText;
    if (result) {
        $.ajax({
            type: "POST",
            url: 'DeleteCliente.ashx',
            data: { id },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (Terr) {
                console.log(Terr);

            },
        });
        document.getElementById("contenido").innerHTML = "";
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
                    var item = "<tr id=" + Terr[i].id + ">"
                        + "<td>" + Terr[i].id + "</td>"
                        + "<td>" + Terr[i].razonSocial + "</td>"
                        + "<td>" + Terr[i].direccion + "</td>"
                        + "<td><button type='button'  class='btn iconcss' onclick='EditCliente(" + Terr[i].id + ")'><img src='https://img.icons8.com/android/24/000000/edit.png'/></button><button type='button'  class='btn iconcss' onclick='deleteCliente(" + Terr[i].id + ")'><img src='https://img.icons8.com/material-rounded/24/000000/erase.png'/></button></td>"
                        + "</tr>";
                    $('#t01').append(item);

                }

                $('#t01').show();
            },
        });
    }
}

function validateID() {
    var text = document.getElementById("id").value;
    let re = /[0-9,$]{2,3}/;
    var maximo = Number(text)
    if (re.test(text) && maximo <= 100 && maximo >= 10) {
        document.getElementById("btnsave").disabled = false;
        document.getElementById("id").style.borderColor = 'green';
        document.getElementById("infoerror").style.display= 'none';
    } else {
        document.getElementById("btnsave").disabled = true;
        document.getElementById("id").style.borderColor = 'red';
        document.getElementById("infoerror").style.display= 'block';
    }
}