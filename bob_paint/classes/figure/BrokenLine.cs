using System;
using System.Collections.Generic;
using System.Drawing;

namespace bob_paint.classes.figure
{
    public class BrokenLine : baseShape
    {
        private List<Point> _points;

        public BrokenLine(List<Point> points, Color color, float width)
            : base(color, width)
        {
            _points = new List<Point>(points);
        }

        public override void Draw(Graphics graphics)
        {
            if (_points.Count < 2) return; 

            pen.Color = ColorLine;
            pen.Width = WidthLine;
            graphics.DrawLines(pen, _points.ToArray());
        }
        public void AddPoint(Point newPoint)
        {
            _points.Add(newPoint);
        }

        public void ClearPoints()
        {
            _points.Clear();
        }

        public int PointsCount => _points.Count;
        public Point FirstPoint => _points.Count > 0 ? _points[0] : Point.Empty;
        public Point LastPoint => _points.Count > 0 ? _points[_points.Count - 1] : Point.Empty;
    }
}