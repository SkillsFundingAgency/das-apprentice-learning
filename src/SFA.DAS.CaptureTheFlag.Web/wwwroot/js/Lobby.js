'use strict'

window.setInterval(function () {

    var url = "/lobby/refresh?gameId=" + pageModel.Id
    
    var httpRequest = new XMLHttpRequest();

    httpRequest.open("GET", url, false);

    httpRequest.send();
    
    UpdateLobby(JSON.parse(httpRequest.responseText))

}, 1500);

function UpdatePlayerReady() {
    var url = "/lobby/update?gameId=" + pageModel.Id + "&playerId=" + pageModel.PlayerId

    var httpRequest = new XMLHttpRequest();

    httpRequest.open("GET", url, false);

    httpRequest.send();

    var response = JSON.parse(httpRequest.responseText) 

    UpdateLobby(response)
}

function UpdateLobby(jsModel) {

    if (jsModel.Setup.Players[0].Ready == true && jsModel.Setup.Players[1].Ready == true)
    {
        window.location.href = "https://localhost:44353/Game/Index?gameId=" + pageModel.Id + "&playerId=" + pageModel.PlayerId;
    }
    
  
    document.getElementById("start-button").disabled = !jsModel.Setup.PlayersConnected;
    document.getElementById("waiting-for-opponent-message").hidden = jsModel.Setup.PlayersConnected;

    opponent = jsModel.Setup.Players.find(p => p.Id != pageModel.PlayerId)
    document.getElementById("opponent-ready-message").hidden = opponent.Ready != true

}