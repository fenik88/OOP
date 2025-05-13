using bob_paint.classes.figure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bob_paint
{
    public partial class Form1 : Form
    {
        private List<baseShape> shapes; 
        private Point tempStartPoint;
        private Point tempEndPoint;
        private bool isDrawing;
        private string selectedShape;
        private Pen tempPen;
        public Form1()
        {
            InitializeComponent();
            shapes = new List<baseShape> { };
            tempPen = new Pen(Color.Black, 2);


            LineToolStripMenuItem.Image = Properties.Resources.Line;
            rectangleToolStripMenuItem.Image = Properties.Resources.Rectangle;
            EllipsToolStripMenuItem.Image = Properties.Resources.Ellips;
            PolygonToolStripMenuItem.Image = Properties.Resources.Polygon;
            BrokenLineToolStripMenuItem.Image = Properties.Resources.BrokenLine;

            contextMenuStripBaseFigure.ImageScalingSize = new Size(32, 32);
            ShapeButton.ContextMenuStrip = contextMenuStripBaseFigure;




            ShapeButton.Image = Properties.Resources.Line;
            ShapeButton.MouseDown += new MouseEventHandler(ShapeButton_MouseDown);
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectedShape = "Line";
            ColorButton.BackColor= Color.Black;
        }

 

        private void ShapeButton_MouseDown(object sender, MouseEventArgs e)
        {
           
            if (e.Button == MouseButtons.Right)
            {

                Point location = new Point(ShapeButton.Left + ShapeButton.Width , ShapeButton.Top);

               
                ShapeButton.ContextMenuStrip.Show(ShapeButton, location);
               
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics); 
            }

            if (isDrawing)
            {
                baseShape temporaryShape = null;

                if (selectedShape == "Line")
                {
                    temporaryShape = new LineShape(tempStartPoint, tempEndPoint, tempPen.Color, tempPen.Width);
                }
                else if (selectedShape == "Rectangle")
                {
                    temporaryShape = new RectangleShape(tempStartPoint, tempEndPoint, tempPen.Color, tempPen.Width);
                }

                if (temporaryShape != null)
                {
                    temporaryShape.Draw(e.Graphics);
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !string.IsNullOrEmpty(selectedShape))
            {
                tempStartPoint = e.Location; 
                isDrawing = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                tempEndPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDrawing && !string.IsNullOrEmpty(selectedShape))
            {
                tempEndPoint = e.Location;
                baseShape newShape = null;

                if (selectedShape == "Line")
                {
                    newShape = new LineShape(tempStartPoint, tempEndPoint, tempPen.Color, tempPen.Width);
                }
                else if (selectedShape == "Rectangle")
                {
                    newShape = new RectangleShape(tempStartPoint, tempEndPoint, tempPen.Color, tempPen.Width);
                }

                if (newShape != null)
                {
                    shapes.Add(newShape);
                }

                isDrawing = false;
                pictureBox1.Invalidate();
            }
        }

        // LINE
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            pictureBox1.Invalidate();
            selectedShape = "Line";
        }

        // RECTANGLE
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShape = "Rectangle";
        }

        //POLYGON
        private void PolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShape = "Polygon";
        }

        //ELLIPS
        private void EllipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShape = "Ellips";
        }

        //BROKEN LINE
        private void BrokenLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShape = "BrokenLine";
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    tempPen.Color = colorDialog.Color; 
                    ColorButton.BackColor = colorDialog.Color;
                }
            }
        }

        private void ShapeButton_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
