using DAS_Capture_The_Flag.Application.Models.GameModels;

namespace DAS_Capture_The_Flag.GameHandlers
{
    public class PlayersTurnHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            dynamic requestObject = request;

            Game game = requestObject.game;
            int player = requestObject.player;

            if (player == game.PlayersTurn)
            {
                return base.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
}
