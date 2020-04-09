'use strict'



function UpdatePlayerReady(Id, PlayerId) {
    var url = "/lobby/update?gameId=" + Id + "&playerId=" + PlayerId

    var httpRequest = new XMLHttpRequest();

    httpRequest.open("GET", url, false);

    httpRequest.send();

    //var response = JSON.parse(httpRequest.responseText) 

    //UpdateLobby(response)
}


