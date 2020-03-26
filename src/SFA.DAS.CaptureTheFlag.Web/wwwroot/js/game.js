
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();

console.log(pirates)

connection.start().then(function () {
   
    connection.invoke("UpdatePlayerConnectionId",pirates.id, pirates.playerId).catch(function (err) {
        return console.error(err.toString());
    });  

}).catch(function (err) {


    return console.error(err.toString());
});
