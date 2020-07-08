using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.MapService
{
    public class Map : IMap
    {
        public string GetTileCSS(int tile)
        {
            switch (tile)
            {
                case 0:
                    return "tile-grass";
                case 1:
                    return "tile-wall";
                default:
                    return "tile";
            }
        }

        public bool GetTileWalkable(int tile)
        {
            switch (tile)
            {
                case 0:
                    return true;
                case 1:
                    return false;
                default:
                    return true;
            }
        }

        public int GetScreenPosition(int gridCoord)
        {
            //TODO replace with constant for tile width/height
            return (gridCoord * 40) + 5;
        }
    }
}
