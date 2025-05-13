using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bob_paint.classes.figure
{
    internal class Polygon : baseShape
    {
        protected int nLines;
        protected Point startPosition { set; get; }
        protected Point endPosition { set; get; }
        protected Color ColorFill { get; set; }

        public Polygon(Point start, Point end, Color colorL, float widthL, Color colorF, int nLines) : base(colorL, widthL)
        {
            this.startPosition = start;
            this.endPosition = end;
            ColorFill = colorF;
            this.nLines = nLines;
        }

        public override void Draw(Graphics graphics)
        {
            double degH = 2 * Math.PI / nLines;
            PointF[] points = new PointF[nLines];

            float a = Math.Abs(startPosition.X - endPosition.X) / 2;
            float b = Math.Abs(startPosition.Y - endPosition.Y) / 2;
            float centerX = (startPosition.X + endPosition.X) / 2; 
            float centerY = (startPosition.Y + endPosition.Y) / 2;

            for (int i = 0; i < nLines; i++)
            {
                double angle = i * degH;
                float tempX = centerX + a * (float)Math.Cos(angle);
                float tempY = centerY + b * (float)Math.Sin(angle); 

                points[i] = new PointF(tempX, tempY);
            }

            graphics.DrawPolygon(pen, points);
        }
    }
}
