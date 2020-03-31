
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();


connection.start().then(function () {
   
    connection.invoke("UpdatePlayerConnectionId",game.id, game.playerId, game).catch(function (err) {
        return console.error(err.toString());
    });  

}).catch(function (err) {

    return console.error(err.toString());
});

var canvas = null;
var ctx = null;
var tileW = 50;
var tileH = 50;
var mapW = 10;
var mapH = 10;

window.onload = function () {
    setUpCanvas();
    requestAnimationFrame(drawGame);
}

function drawGame() {
    if (ctx == null) { return; }

    DrawMap();

    requestAnimationFrame(drawGame);
}

function setUpCanvas() {
    canvas = document.getElementById('GameWindow');
    ctx = canvas.getContext('2d');
    canvas.addEventListener('click', function (event) {

        console.log(getTileClicked(event));
    });
}

function getTileClicked(event) {
    return { x : (Math.floor(event.offsetX / tileW )), y : Math.floor(event.offsetY/tileH)}
}