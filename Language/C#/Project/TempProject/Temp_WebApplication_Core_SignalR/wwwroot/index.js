let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        //.withUrl("/counthub", signalR.HttpTransportType.LongPolling)  //指定协议
        .withUrl("/counthub")  //不指定协议的话，会按照 WebSocket > ServerSentEvents > LongPolling 这样的优先级降级选择协议
        .build();

    connection.on("ReceiveUpdate", (update) => {
        const resultDiv = document.getElementById("result");
        resultDiv.innerHTML = update;
    });

    connection.on("someFunc", function (obj) {
        const resultDiv = document.getElementById("result");
        resultDiv.innerHTML = "Someone called, parameters: " + obj.random;
    });

    connection.on("finished", function () {
        connection.stop();
        const resultDiv = document.getElementById("result");
        resultDiv.innerHTML = "Done, Finished";
    });

    connection.start()
        .catch(err => console.error(err.toString()));
}

setupConnection();

document.getElementById("submit").addEventListener("click", e => {
    e.preventDefault();

    //访问CountController，CountController给了路由Attribute：[Route("api/count")]
    fetch("/api/count",
        {
            //访问CountController中的Post方法
            method: "POST",
            headers: {
                'content-type': 'application/json'
            }
        })
        //获取CountController中MyPost方法的返回值，这里是1
        .then(response => response.text())
        //调用CountHub中的GetLatestCount方法
        .then(id => connection.invoke("GetLatestCount", id));
});