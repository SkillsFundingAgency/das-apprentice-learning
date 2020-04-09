using System.Collections.Generic;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    
    public class GameData
    {
        public string[,] ChosenMap { get; set; }

        public List<Soldier> Soldiers { get; set; }

        public GameData()
        {
            // [TODO] - Fake data to get working will be replaced real data in an upcoming commit
            Soldiers = new List<Soldier>() { new Soldier(1, 0, 0), new Soldier(2, 9, 9) };
            ChosenMap = new string[10, 10];
        }
    } 
}
