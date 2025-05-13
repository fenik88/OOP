using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bob_paint.classes.figure
{
    internal class RectangleShape:baseShape
    {
        public Point startPosition { set; get; }
        public Point endPosition { set; get; }

        public RectangleShape(Point start, Point end, Color color, float width) : base(color, width)
        {
            this.startPosition = start;
            this.endPosition = end;
        }

        public override void Draw(Graphics graphics)
        {

            graphics.DrawLine(pen, startPosition, new Point(endPosition.X, startPosition.Y));
            graphics.DrawLine(pen, startPosition, new Point(startPosition.X, endPosition.Y));
            graphics.DrawLine(pen, endPosition, new Point(endPosition.X, startPosition.Y));
            graphics.DrawLine(pen, endPosition, new Point(startPosition.X, endPosition.Y));


        }
    }
}
