using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.MapService
{
    public interface IMap
    {
        public string GetTileCSS(int tile);
        public int GetScreenPosition(int gridCoord);
        public bool GetTileWalkable(int tile);
    }
}
