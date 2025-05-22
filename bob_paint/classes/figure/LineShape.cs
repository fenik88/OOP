using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bob_paint.classes.figure
{
    internal class LineShape : BaseShape
    {

        public string Type { get; set; } = "Line";
        
        public int StartX { get; set; }

       
        public int StartY { get; set; }

       
        public int EndX { get; set; }

        public int EndY { get; set; }

    
        public Point startPosition => new Point(StartX, StartY);

       
        public Point endPosition => new Point(EndX, EndY);

       

        public LineShape(Point start, Point end, Color colorL, float widthL) : base(colorL, widthL)
        {
            StartX = start.X;
            StartY = start.Y;
            EndX = end.X;
            EndY = end.Y;
        }

        public override void Draw(Graphics graphics)
        {
             
            graphics.DrawLine(pen, startPosition, endPosition);
        }
    }
}
