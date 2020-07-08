
using DAS_Capture_The_Flag.Application.Models.GameModels;
using System;
using System.Linq;

namespace DAS_Capture_The_Flag.GameHandlers
{
    public class HighlightSoldierHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            dynamic requestObject = request;

            Game game = requestObject.game;
            int player = requestObject.player;
            Guid soldierId = requestObject.soldierId;

            var soldier = game.Data.Soldiers.First(s => s.Id == soldierId);

            if (soldier.Player == player)
            {
                soldier.Selected = !soldier.Selected;
            }

            return base.Handle(request);
        }
    }
}
