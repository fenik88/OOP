using System;
using System.Drawing;

namespace bob_paint
{
    public abstract class BaseShape
{
        public Color ColorLine { get; set; }
        public float WidthLine { get; set; }

        public Pen pen;

        public BaseShape(Color colorL, float widthL)
        {

            ColorLine = colorL;
            WidthLine = widthL;
            pen = new Pen(ColorLine, WidthLine);
        }

        public abstract void Draw(Graphics graphics);


}
}
