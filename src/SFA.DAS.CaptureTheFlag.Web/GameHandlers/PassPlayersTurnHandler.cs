using DAS_Capture_The_Flag.Application.Models.GameModels;

namespace DAS_Capture_The_Flag.GameHandlers
{
    public class PassPlayersTurnHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            dynamic requestObject = request;

            Game game = requestObject.game;

            game.PlayersTurn = (game.PlayersTurn == 1) ? 2 : 1;

            return null;
        }
    }
}
