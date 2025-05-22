using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bob_paint.classes.figure
{
    internal class EllipsShape: BaseShape
    {
        public string Type { get; set; } = "Polygon";

        public int StartX { get; set; }

        public int StartY { get; set; }

        public int EndX { get; set; }

        public int EndY { get; set; }

        public Color FillColor { get; set; }

        public Point startPosition => new Point(StartX, StartY);

        public Point endPosition => new Point(EndX, EndY);

        public EllipsShape(Point start, Point end, Color colorL, float widthL, Color colorF) : base(colorL, widthL)
        {
            StartX = start.X;
            StartY = start.Y;
            EndX = end.X;
            EndY = end.Y;
            FillColor = colorF;
        }

        public override void Draw(Graphics graphics)
        {
            AdjustCoordinates();
            Brush brush = (FillColor != Color.FromArgb(255, 255, 255, 255)) ? new SolidBrush(FillColor) : null;
            Rectangle rect = new Rectangle(startPosition.X, startPosition.Y, Math.Abs(endPosition.X-startPosition.X), Math.Abs(endPosition.Y - startPosition.Y));
            if (brush != null)
            {
                graphics.FillEllipse(brush, rect);
            }
          
            graphics.DrawEllipse(pen, rect);
        }
        public void AdjustCoordinates()
        {
            if (startPosition.X > endPosition.X)
            {
                int temp = startPosition.X;
                StartX = endPosition.X;
                StartY = startPosition.Y;
                EndX = temp;
                EndY = endPosition.Y;
            }
            if (startPosition.Y > endPosition.Y)
            {
                int temp = startPosition.Y;
                StartX = startPosition.X;
                StartY = endPosition.Y;
                EndX = endPosition.X;
                EndY = temp;
            }
        }
    }
}
