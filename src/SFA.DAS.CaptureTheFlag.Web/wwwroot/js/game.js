
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();


connection.start().then(function () {
   
    connection.invoke("UpdatePlayerConnectionId",game.Id, game.PlayerId, game).catch(function (err) {
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

var soldierPlayerOne = new Image(40, 40);
var soldierPlayerTwo = new Image(40, 40);
soldierPlayerOne.src = "../lib/Game/Assets/soldier-player-1.png";
soldierPlayerTwo.src = "../lib/Game/Assets/soldier-player-2.png";


window.onload = function () {
    setUpCanvas();
    requestAnimationFrame(drawGame);
    
}
connection.on("UpdateModel", function (newGame ) {
    
    newGame = JSON.parse(newGame);
    
    game = newGame;
    console.log(game);
});


function drawGame() {
    if (ctx == null) { return; }

    DrawMap();
    DrawSoldiers();

    requestAnimationFrame(drawGame);
}

function setUpCanvas() {
    canvas = document.getElementById('GameWindow');
    ctx = canvas.getContext('2d');
    canvas.addEventListener('click', function (event) {

        connection.invoke("CanvasClickController", getTileClicked(event).x, getTileClicked(event).y, game.Game.Id).catch(function (err) {
            return console.error(err.toString());
        });
        console.log(getTileClicked(event));
    });
}

function getTileClicked(event) {
    return { x : (Math.floor(event.offsetX / tileW )), y : Math.floor(event.offsetY/tileH)}
}

function DrawSoldiers() {
    var soldiers = game.Game.Data.Soldiers;

    soldiers.forEach(soldier => {
    
        if (soldier.Selected == true) {
            highlightSoldier(soldier.xPos * tileW, soldier.yPos * tileH);
            highlightPotentialMoves(soldier.PotentialMoves);
        }
        if (soldier.Player == 1)
        {
            ctx.drawImage(soldierPlayerOne, soldier.xPos * tileW, soldier.yPos * tileH)
        }
        else
        {
            ctx.drawImage(soldierPlayerTwo, soldier.xPos * tileW, soldier.yPos * tileH)
        }

    });
      
}

function highlightSoldier(x, y) {
    ctx.strokeStyle = "#e9ed07"
    ctx.strokeRect(x - 2, y - 2, 44, 44)
}

function highlightPotentialMoves(moves) {
    ctx.globalAlpha = 0.4;

    moves.forEach(move => {
        
        ctx.fillStyle = "#e9ed07";
        ctx.fillRect(move.X * tileW, move.Y * tileH, 50, 50)
        
        
    })
    ctx.globalAlpha = 1.0;
  //  console.log(moves);
}