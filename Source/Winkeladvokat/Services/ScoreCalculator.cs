using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winkeladvokat.Models;

namespace Winkeladvokat.Services
{
    public class ScoreCalculator
    {
        public int GetPlayerScore(Player player, Board board)
        {
            var playerParagraphTokenFields =
                board.Fields.SelectMany(row => row)
                    .Where(field => field.Token != null && field.Token.GetType() == typeof(ParagraphToken) && field.Token.Player == player).ToList();
            return playerParagraphTokenFields.Sum(field => field.Value);
        }
    }
}
