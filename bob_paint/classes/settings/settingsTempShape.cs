using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bob_paint.classes.settings
{
    internal class settingsTempShape
    {
      
        public Point startPosition { get; set; } = new Point();
        public Point endPosition { get; set; } = new Point();

        public Color StrokeColor { get; set; } = Color.Black;
        public Color FillColor { get; set; } = Color.FromArgb(255, 255, 255, 255);
        public float Width { get; set; } = 2f;
        public string selectedShape { get; set; } = string.Empty;

        public bool isDrawing { get; set; } = false;
        public bool isRotateX { get; set; } = false;
        public bool isRotateY { get; set; } = false;



        public void AdjustCoordinates()
        {
            if (startPosition.X > endPosition.X)
            {
                int temp = startPosition.X;
                startPosition = new Point(endPosition.X, startPosition.Y);
                endPosition = new Point(temp, endPosition.Y);
                isRotateX = true;
            }
            if (startPosition.Y > endPosition.Y)
            {
                int temp = startPosition.Y;
                startPosition = new Point(startPosition.X, endPosition.Y);
                endPosition = new Point(endPosition.X, temp);
                isRotateY=true;
            }
        }

        public void RotateX()
        {
            if (isRotateX)
            {
                int temp = this.startPosition.X;
                this.startPosition = new Point(this.endPosition.X, this.startPosition.Y);
                this.endPosition = new Point(temp, this.endPosition.Y);
                isRotateX = false;
            }
            
        }

        public void RotateY()
        {
            if (isRotateY)
            {
                int temp = this.startPosition.Y;
                this.startPosition = new Point(this.startPosition.X, this.endPosition.Y);
                this.endPosition = new Point(this.endPosition.X, temp);
                isRotateY = false;
            }
        }


        // public IShapePlugin CurrentPlugin { get; set; }
    }
}
