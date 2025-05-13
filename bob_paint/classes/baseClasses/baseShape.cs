using System;
using System.Drawing;

namespace bob_paint
{
    internal abstract class baseShape
{
    public Color ColorLine { get; set; }
    public float WidthLine { get; set; }

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
