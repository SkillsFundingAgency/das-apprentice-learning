"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();


connection.start().then(function () {
    console.log("Starting starting the actual game");
    connection.invoke("TestMethod");
}).catch(function (err) {
    return console.error(err.toString());
});

window.onload(() => {
    console.log("loading after on load")
    connection.invoke("TestMethod");
})