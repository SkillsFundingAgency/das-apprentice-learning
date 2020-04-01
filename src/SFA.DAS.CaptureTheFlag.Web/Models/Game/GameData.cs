using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Models.Game
{
    
    public class GameData
    {
        public int[,] ChosenMap { get; set; }

        public List<Soldier> Soldiers { get; set; }

        public int PlayersTurn { get; set; }

       

        public GameData()
        {
            Soldiers = new List<Soldier>() { new Soldier(1, 0, 0) , new Soldier(2, 9, 9) };
            ChosenMap = new int[10, 10]
                                    {
                                        { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                                    };
            PlayersTurn = 1;
        }
    } 
}
