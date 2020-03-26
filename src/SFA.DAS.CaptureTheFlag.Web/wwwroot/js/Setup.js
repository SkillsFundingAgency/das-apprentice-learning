"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/setuphub").build();

connection.start().then(function () {
    console.log("Starting connection");
}).catch(function (err) {
    return console.error(err.toString());
});


var startButton = document.getElementById("start-button");

startButton.addEventListener("click", function (event) {

    console.log("Player ready to start")

    connection.invoke("UpdatePlayerReady").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


connection.on("AwaitPlayersReady", () => {
    var StartButton = document.getElementById("start-button");
   
    StartButton.removeAttribute('disabled')
})

connection.on("StartGame",  function( gameId, playerId ){
    console.log("Both players ready");
    window.location.href = "https://localhost:44353/Game/Index?gameId="+gameId+"&playerId="+playerId;
    console.log("Redirected")
})

connection.on("OpponentLeftLobby", function() {
    console.log("Opponent left");

    document.getElementById("opponent-ready-message").addAttribute("hidden");
    var StartButton = document.getElementById("start-button");
    StartButton.disabled = true;
})


connection.on("PlayerReady", function (playerOne , playerTwo) {
   
    document.getElementById("waiting-for-player-message-1").hidden = playerOne;

    document.getElementById("waiting-for-player-message-2").hidden = playerTwo;
    
    console.log("Player Ready: " + player)
})

connection.on("OpponentReady", () => {
    document.getElementById("opponent-ready-message").removeAttribute("hidden");
})
