﻿namespace Winkeladvokat.Models
{
    using System.Windows;
    using System.Windows.Media;

    public class BoardField
    {
        public BoardField(int value, Brush color, Point position)
        {
            this.Value = value;
            this.FieldColor = color;
            this.Position = position;
        }

        public static BoardField Empty
        {
            get { return new BoardField(0, new SolidColorBrush(Colors.Transparent), default(Point)); }
        }

        public int Value { get; set; }

        public Brush FieldColor { get; set; }

        public Point Position { get; set; }

        public Player Player { get; set; }

        public Token Token { get; set; }

        public bool HasToken
        {
            get { return this.Token != null; }
        }
    }
}
