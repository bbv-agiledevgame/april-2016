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
        public List<int> GetScores(List<Player> players, Board board)
        {
            var scoreList = players.Select(player => this.GetPlayerScore(player, board));

            return scoreList.ToList();
        }

        private int GetPlayerScore(Player player, Board board)
        {
            var playerParagraphTokenFields =
                board.Fields.SelectMany(row => row)
                    .Where(field => field.Token != null && field.Token.Type == TokenType.Paragraph && field.Token.Player == player).ToList();
            return playerParagraphTokenFields.Sum(field => field.Value);
        }
    }
}
