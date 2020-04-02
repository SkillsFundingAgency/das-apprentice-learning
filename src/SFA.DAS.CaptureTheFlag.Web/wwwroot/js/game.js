
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();


connection.start().then(function () {
   
    connection.invoke("UpdatePlayerConnectionId",game.Id, game.PlayerId, game).catch(function (err) {
        return console.error(err.toString());
    });  

}).catch(function (err) {


    return console.error(err.toString());
});
