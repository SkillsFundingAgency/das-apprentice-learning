using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Application.Models.GameModels
{
    
    public class GameData
    {
        public string[,] ChosenMap { get; set; }

        public List<Soldier> Soldiers { get; set; }

        public GameData()
        {
            Soldiers = new List<Soldier>() { new Soldier(1, 0, 0), new Soldier(2, 9, 9) };
            ChosenMap = new string[5, 5]
                                    {
                                        { "grass", "wall", "wall", "wall", "wall"},
                                        { "wall", "wall", "grass", "grass", "grass"},
                                        { "grass", "grass", "grass", "grass", "grass"},
                                        { "grass", "grass", "grass", "grass", "grass"},
                                        { "grass", "grass", "grass", "grass", "grass"}
                                    };
        }
    } 
}
