using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.ViewModels
{
    public class GameViewModel
    {
        public string Id { get; set; }
        public string PlayerId { get; set; }

        public GameViewModel(string id, string playerId)
        {
            Id = id;
            PlayerId = playerId;
        }
    }
}
