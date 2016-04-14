namespace Winkeladvokat
{
    using System.Collections.Generic;
    using System.Windows;

    public static class Utils
    {
        public static Dictionary<int, Point> PlayerStartPositions = new Dictionary<int, Point>()
        {
            { 0, new Point(0, 0) },
            { 1, new Point(0, 7) },
            { 2, new Point(7, 0) },
            { 3, new Point(7, 7) }
        };
    }
}
