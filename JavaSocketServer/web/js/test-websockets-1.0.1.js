var host = 'ws://216.231.128.40:10669/JavaSocketServer/wsServer';

function show(message) {
    $("#messages").html(message);
}

function connect() {
    var ws = new WebSocket(host);

    ws.onopen = function () {
        show("Conectado");
    };

    ws.onmessage = function (event) {
        var data = JSON.parse(event.data);
        console.log(JSON.stringify(data, null, 2));
        if (data.Command === "registrado") {
            ws.send("Probando desde Web");
            console.log("Enviando Mensaje");
        }
    };

    ws.onclose = function () {
        show("Desconectado", "error");
    };

    ws.onerror = function () {
        show("Error", "warning");
    };
}

$(document).ready(function () {
    $("#connect-socket").click(function () {
        connect();
    });
});