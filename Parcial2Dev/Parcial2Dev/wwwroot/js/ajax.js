$("#buscarUsuario").click(function () {

    var usuarioId = parseInt($("#usuarioIdConAjax").val());

    console.log(usuarioId);

    var json = {}
    json["id"] = usuarioId;

    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/BuscarUsuarioConAjax",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            $("#usuario").html("" +
                "<p><b>Numero de Identificación: </b>" + response["id"] + "</p>" +
                "<p><b>Usuario: </b>" + response["user"] + "</p>" +
            "");

        }

    })

});