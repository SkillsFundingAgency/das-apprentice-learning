using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ConnectionId { get; set; }
        public bool Ready { get; set; }
        public int Number { get; set; }
        
    }
}
