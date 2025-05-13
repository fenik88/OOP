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
        public Point tempStartPoint { get; set; } = new Point();
        public Point tempEndPoint { get; set; } = new Point();

        public Color StrokeColor { get; set; } = Color.Black;
        public Color FillColor { get; set; } = Color.FromArgb(255, 255, 255, 255);
        public float Width { get; set; } = 2f;
        public string selectedShape { get; set; } = string.Empty;

        public bool isDrawing { get; set; } = false;
        public bool isRotateX { get; set; } = false;
        public bool isRotateY { get; set; } = false;


        public ShapeType SelectedShape { get; set; } = ShapeType.Line;


        public void AdjustCoordinates()
        {
            if (tempStartPoint.X > tempEndPoint.X)
            {
                int temp = tempStartPoint.X;
                tempStartPoint = new Point(tempEndPoint.X, tempStartPoint.Y);
                tempEndPoint = new Point(temp, tempEndPoint.Y);
                isRotateX = true;
            }
            if (tempStartPoint.Y > tempEndPoint.Y)
            {
                int temp = tempStartPoint.Y;
                tempStartPoint = new Point(tempStartPoint.X, tempEndPoint.Y);
                tempEndPoint = new Point(tempEndPoint.X, temp);
                isRotateY=true;
            }
        }

        public void RotateX()
        {
            if (isRotateX)
            {
                int temp = this.tempStartPoint.X;
                this.tempStartPoint = new Point(this.tempEndPoint.X, this.tempStartPoint.Y);
                this.tempEndPoint = new Point(temp, this.tempEndPoint.Y);
                isRotateX = false;
            }
            
        }

        public void RotateY()
        {
            if (isRotateY)
            {
                int temp = this.tempStartPoint.Y;
                this.tempStartPoint = new Point(this.tempStartPoint.X, this.tempEndPoint.Y);
                this.tempEndPoint = new Point(this.tempEndPoint.X, temp);
                isRotateY = false;
            }
        }


        // public IShapePlugin CurrentPlugin { get; set; }
    }
}
