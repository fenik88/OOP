using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bob_paint.classes.figure
{
    internal class Polygon : BaseShape
    {

        public string Type { get; set; } = "Polygon";


        public int Nlines { get; set; }

     
        public int StartX { get; set; }

        public int StartY { get; set; }

        public int EndX { get; set; }

        public int EndY { get; set; }


        public Color FillColor { get; set; }

        public Point startPosition => new Point(StartX, StartY);

        public Point endPosition => new Point(EndX, EndY);
        public Polygon(Point start, Point end, Color colorL, float widthL, Color colorF, int nLines) : base(colorL, widthL)
        {
            StartX = start.X;
            StartY = start.Y;
            EndX = end.X;
            EndY = end.Y;
            FillColor = colorF;
            Nlines = nLines;
        }

        public override void Draw(Graphics graphics)
        {
           
            double degH = 2 * Math.PI / Nlines;
            PointF[] points = new PointF[Nlines];

            float a = Math.Abs(startPosition.X - endPosition.X) / 2;
            float b = Math.Abs(startPosition.Y - endPosition.Y) / 2;
            float centerX = (startPosition.X + endPosition.X) / 2; 
            float centerY = (startPosition.Y + endPosition.Y) / 2;

            for (int i = 0; i < Nlines; i++)
            {
                double angle = i * degH;
                float tempX = centerX + a * (float)Math.Cos(angle);
                float tempY = centerY + b * (float)Math.Sin(angle); 

                points[i] = new PointF(tempX, tempY);
            }
            using (Brush brush = new SolidBrush(FillColor))
            {
                graphics.FillPolygon(brush, points);
            }
            graphics.DrawPolygon(pen, points);
        }
    }
}
