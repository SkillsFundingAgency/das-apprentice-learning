using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.MapService;
using System.Linq;

namespace DAS_Capture_The_Flag.GameHandlers
{
    public class MoveSoldierHandler : AbstractHandler
    {
        private readonly IMap _map;

        public MoveSoldierHandler(IMap map)
        {
            _map = map;
        }
        public override object Handle(object request)
        {
            dynamic requestObject = request;

            Game game = requestObject.game;
            int x = requestObject.x;
            int y = requestObject.y;

            var soldier = game.Data.Soldiers.First(s => s.Selected);

            if (soldier != null)
            {
                if (_map.GetTileWalkable(game.Data.ChosenMap[y][x]))
                {
                    soldier.xPos = x;
                    soldier.yPos = y;
                    soldier.Selected = false;

                    return base.Handle(request);
                }
            }

            return null;
        }
    }
}
