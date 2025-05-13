using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bob_paint.classes.figure
{
    internal class LineShape : baseShape
    {

        protected Point startPosition { set; get; }
        protected Point endPosition { set; get; }

       

        public LineShape(Point start, Point end, Color colorL, float widthL) : base(colorL, widthL)
        {
            this.startPosition = start;
            this.endPosition = end;
        }

        public override void Draw(Graphics graphics)
        {
             
            graphics.DrawLine(pen, startPosition, endPosition);
        }
    }
}
