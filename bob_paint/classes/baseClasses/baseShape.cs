using System;
using System.Drawing;

namespace bob_paint
{
    internal abstract class baseShape
{
    protected Color ColorLine { get; set; }
    protected float WidthLine { get; set; }

    protected Pen pen;

        public baseShape(Color colorL, float widthL)
        {

            ColorLine = colorL;
            WidthLine = widthL;
            pen = new Pen(ColorLine, WidthLine);
        }

        public abstract void Draw(Graphics graphics);
}
}
