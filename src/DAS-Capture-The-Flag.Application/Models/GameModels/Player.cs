using System;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    public class Player
    {
        public Guid Id { get; set; }
        public string ConnectionId { get; set; }
        public bool Ready { get; set; }
        
        
    }
}
