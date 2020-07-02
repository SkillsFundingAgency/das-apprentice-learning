using System;
using System.Collections.Generic;
using System.Text;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    public class PlayerDetails
    {
        public string UserName { get; set; }

        public PlayerDetails(string username)
        {
            UserName = username;
        }
    }
}
