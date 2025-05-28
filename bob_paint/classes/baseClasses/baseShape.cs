using System;
using Newtonsoft.Json;
using System.Drawing;

namespace bob_paint
{
    public abstract class BaseShape
{
        [JsonProperty("StrokeColor")]
        public int StrokeColorArgb
        {
            get => ColorLine.ToArgb();
            set => ColorLine = Color.FromArgb(value);
        }
        [JsonIgnore]
        public Color ColorLine { get; set; }
        [JsonProperty("Width")]
        public float WidthLine { get; set; }

        public Pen pen;

        public BaseShape(Color colorL, float widthL)
        {

            ColorLine = colorL;
            WidthLine = widthL;
            pen = new Pen(ColorLine, WidthLine);

        }

        public abstract void Draw(Graphics graphics);

        public void UpdatePen()
        {
            pen?.Dispose();
            pen = new Pen(ColorLine, WidthLine);
        }


    }
}
