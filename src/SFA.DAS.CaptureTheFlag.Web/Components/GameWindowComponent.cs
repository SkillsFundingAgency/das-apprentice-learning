using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MediatR;

using DAS_Capture_The_Flag.Application.Handlers.GetGame;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.MapService;
using Microsoft.Extensions.Configuration;

namespace DAS_Capture_The_Flag.Components
{
    public class GameWindowComponent : ComponentBase
    {
        [Inject] public IMediator Mediator { get; set; }
        [Inject] public IMap Map { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }

        [Parameter] public Guid GameId {get;set;}
        [Parameter] public Guid PlayerId { get; set; }

        private HubConnection _hubConnection;
        public bool IsConnected =>_hubConnection.State == HubConnectionState.Connected;

        public Game Game { get; set; }
        public int PlayerNumber { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Game = await Mediator.Send(new GetGameRequest(GameId));

            PlayerNumber = GetPlayerNumber();
           
            _hubConnection = new HubConnectionBuilder()
               .WithUrl(Configuration.GetValue<string>("GameHubConnectionUrl"))
               .Build();

            _hubConnection.On("UpdateGame", async () =>
            {
                Game = await Mediator.Send(new GetGameRequest(GameId));
                StateHasChanged();
            });

            await _hubConnection.StartAsync();

            await _hubConnection.SendAsync("UpdatePlayerConnectionId", GameId, PlayerId);
        }

        public Task ClickTile(int x, int y) => _hubConnection.SendAsync("TileClick", GameId, PlayerNumber, x, y);
        public Task ClickSoldier(Guid gameId, int player, Guid soldierId) => _hubConnection.SendAsync("SoldierClick", gameId, player, soldierId);

        public int GetPlayerNumber()
        {
            return (PlayerId == Game.Players.PlayerOne.Id ? 1 : 2); 
        }

    }
}
