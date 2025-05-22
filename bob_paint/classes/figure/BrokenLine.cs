using System;
using System.Collections.Generic;
using System.Drawing;

namespace bob_paint.classes.figure
{
    public class BrokenLine : BaseShape
    {

        public string Type { get; set; } = "BrokenLine";
        public List<Point> Points { get; set; }


        public BrokenLine(List<Point> points, Color color, float width)
            : base(color, width)
        {
            Points = new List<Point>(points);
        }

        public override void Draw(Graphics graphics)
        {
            if (Points.Count < 2) return; 

            pen.Color = ColorLine;
            pen.Width = WidthLine;
            graphics.DrawLines(pen, Points.ToArray());
        }
        public void AddPoint(Point newPoint)
        {
            Points.Add(newPoint);
        }

        public void ClearPoints()
        {
            Points.Clear();
        }
    }
}