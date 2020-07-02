using DAS_Capture_The_Flag.Application.Handlers.GetGame;
using DAS_Capture_The_Flag.Application.Handlers.UpdatePlayerReady;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Web.Models.Lobby;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Components.Lobby
{
    public class LobbyComponent : ComponentBase
    {
        [Inject] public IMediator Mediator { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter] public Guid GameId { get; set; }
        [Parameter] public Guid PlayerId { get; set; }

        public Game Game { get; set; }
        public LobbyDetailsViewModel LobbyVM { get;set;}

       
        protected override async Task OnInitializedAsync()
        {
            Game = await Mediator.Send(new GetGameRequest(GameId));

            LobbyVM = new LobbyDetailsViewModel(Game, PlayerId);

            RefreshLobby();
        }

        public async Task RefreshLobby()
        {
            while (true)
            {
                await Task.Delay(1000);

                Game = await Mediator.Send(new GetGameRequest(GameId));

                if (Game.Players.PlayerOne.Ready && Game.Players.PlayerTwo.Ready)
                {
                    NavigationManager.NavigateTo($"https://localhost:44353/Game?gameId={Game.Id}&playerId={PlayerId}", true);
                    return;
                }

                LobbyVM = new LobbyDetailsViewModel(Game, PlayerId);

                StateHasChanged();
            }
        }

        public void Ready()
        {
            Mediator.Send(new UpdatePlayerReadyCommand(GameId, PlayerId), CancellationToken.None);

            if (Game.Players.PlayerOne.Ready && Game.Players.PlayerTwo.Ready)
            {
                NavigationManager.NavigateTo($"https://localhost:44353/Game?gameId={Game.Id}&playerId={PlayerId}", true);
                return;
            }

            LobbyVM = new LobbyDetailsViewModel(Game, PlayerId);

            StateHasChanged();
        }

    }
}
