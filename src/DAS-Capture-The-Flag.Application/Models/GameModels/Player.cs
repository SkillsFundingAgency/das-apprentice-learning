using System;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    public class Player
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string ConnectionId { get; set; }
        public PlayerDetails Details { get; set; }
        public bool Ready { get; set; }

        public Player()
        {

        }
        public Player(Guid id, PlayerDetails details)
        {
            Id = id;
            Details = details;
        }
    }
}
