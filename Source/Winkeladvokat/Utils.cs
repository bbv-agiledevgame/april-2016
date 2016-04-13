using System.Collections.Generic;
using Winkeladvokat.Models;

namespace Winkeladvokat
{
    public static class Utils
    {
        public static Dictionary<int, Position> PlayerStartPositions = new Dictionary<int, Position>()
        {
            { 0, new Position(0, 0) },
            { 1, new Position(0, 7) },
            { 2, new Position(7, 0) },
            { 3, new Position(7, 7) }
        };
    }
}
