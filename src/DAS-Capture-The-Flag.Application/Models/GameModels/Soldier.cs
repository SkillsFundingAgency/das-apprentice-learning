using System;
using System.Collections.Generic;
using System.Drawing;

namespace DAS_Capture_The_Flag.Models.Game
{
    public class Soldier
    {
        public Guid Id { get; } = Guid.NewGuid();
        public int xPos { get; set; }
        public int yPos { get; set; }
        public int Player { get; set; }
        public bool Selected { get; set; }
        public List<Point> PotentialMoves { get; set; }

        public Soldier(int player, int xpos, int ypos)
        {
            Player = player;
            xPos = xpos;
            yPos = ypos;
            PotentialMoves = new List<Point>();
        }
    }

}