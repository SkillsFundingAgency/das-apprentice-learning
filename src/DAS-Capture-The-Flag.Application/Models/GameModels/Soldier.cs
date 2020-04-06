namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    public class Soldier
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public int Player { get; set; }
        
        public Soldier(int player, int xpos, int ypos)
        {
            Player = player;
            xPos = xpos;
            yPos = ypos;
        }
    }
}