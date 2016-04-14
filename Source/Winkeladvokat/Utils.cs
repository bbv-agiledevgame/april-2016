using Winkeladvokat.Models;

namespace Winkeladvokat
{
    using System.Collections.Generic;
    using System.Windows;

    public static class Utils
    {
        public static Dictionary<int, Models.Position> PlayerStartPositions = new Dictionary<int, Models.Position>()
        {
            { 0, new Models.Position(0, 0) },
            { 1, new Models.Position(7, 7) },
            { 2, new Models.Position(7, 0) },
            { 3, new Models.Position(0, 7) }
        };
    }
}
