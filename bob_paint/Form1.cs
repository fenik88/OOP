using bob_paint.classes.figure;
using bob_paint.classes.lists;
using bob_paint.classes.settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

public enum ShapeType
{
    Line,
    Rectangle,
    Ellips,
    Polygon,
    BrokenLine
}

namespace bob_paint
{
    public partial class Form1 : Form
    {
        private settingsTempShape settingShape = new settingsTempShape();
        private UndoRedoShapes undoRedoShapes = new UndoRedoShapes();
        private List<baseShape> shapes;
        private string selectedShape;
        private List<Point> currentBrokenLinePoints = new List<Point> { };

        public Form1()
        {
            InitializeComponent();
            shapes = new List<baseShape> { };
            
            settingShape.FillColor= Color.FromArgb(255, 255, 255, 255);

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
            shapes= undoRedoShapes.Shapes;
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics); 
            }

            if (settingShape.isDrawing)
            {
                baseShape temporaryShape = null;
                
                if ((selectedShape == "Rectangle") || (selectedShape == "Ellips"))
                {
                    settingShape.AdjustCoordinates();

                }

                if (selectedShape == "Line")
                {
                    temporaryShape = new LineShape(settingShape.tempStartPoint, settingShape.tempEndPoint, settingShape.StrokeColor, settingShape.Width);
                }
                else if (selectedShape == "Rectangle")
                {
                    temporaryShape = new RectangleShape(settingShape.tempStartPoint, settingShape.tempEndPoint, settingShape.StrokeColor, settingShape.Width,settingShape.FillColor);
                }
                else if (selectedShape == "Ellips")
                {
                    temporaryShape = new EllipsShape(settingShape.tempStartPoint, settingShape.tempEndPoint, settingShape.StrokeColor, settingShape.Width, settingShape.FillColor);
                }
                else if (selectedShape == "Polygon")
                {
                    temporaryShape = new Polygon(settingShape.tempStartPoint, settingShape.tempEndPoint, settingShape.StrokeColor, settingShape.Width, settingShape.FillColor,5);
                }
                else if (selectedShape == "BrokenLine")
                {
                    temporaryShape = new BrokenLine (currentBrokenLinePoints, settingShape.StrokeColor, settingShape.Width);
                }

                if (temporaryShape != null)
                {
                    temporaryShape.Draw(e.Graphics);
                }

                    settingShape.RotateX();
                    settingShape.RotateY();

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !string.IsNullOrEmpty(selectedShape))
            {
                settingShape.tempStartPoint = e.Location; 
                settingShape.isDrawing = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (settingShape.isDrawing && selectedShape != "BrokenLine")
            {
                settingShape.tempEndPoint = e.Location;
                pictureBox1.Invalidate();
            }
           

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedShape == "BrokenLine")
            {
                if (e.Button == MouseButtons.Left)
                { currentBrokenLinePoints.Add(e.Location); }
                pictureBox1.Invalidate();
            }

            if (e.Button == MouseButtons.Left && settingShape.isDrawing && !string.IsNullOrEmpty(selectedShape))
            {
         
                settingShape.tempEndPoint = e.Location;
                baseShape newShape = null;

                if ((selectedShape == "Rectangle") || (selectedShape == "Ellips"))
                { 
                    settingShape.AdjustCoordinates();
                    settingShape.isRotateX = false;
                    settingShape.isRotateY = false;
                }

                if (selectedShape == "Line")
                {
                    newShape = new LineShape(settingShape.tempStartPoint, settingShape.tempEndPoint, settingShape.StrokeColor, settingShape.Width);
                }
                else if (selectedShape == "Rectangle")
                {
                    newShape = new RectangleShape(settingShape.tempStartPoint, settingShape.tempEndPoint, settingShape.StrokeColor, settingShape.Width, settingShape.FillColor);
                }
                else if (selectedShape == "Ellips")
                {
                    newShape = new EllipsShape(settingShape.tempStartPoint, settingShape.tempEndPoint, settingShape.StrokeColor, settingShape.Width, settingShape.FillColor);
                }
                else if (selectedShape == "Polygon")
                {
                    newShape = new Polygon(settingShape.tempStartPoint, settingShape.tempEndPoint, settingShape.StrokeColor, settingShape.Width, settingShape.FillColor, 5);
                }
                else if (selectedShape == "BrokenLine")
                {
                    newShape = new BrokenLine(currentBrokenLinePoints, settingShape.StrokeColor, settingShape.Width);
                   
                }

                if (newShape != null)
                {
                    undoRedoShapes.AddShape(newShape);
                }

                
                settingShape.isDrawing = false;
                pictureBox1.Invalidate();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedShape = "Line";
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShape = "Rectangle";
        }
        private void PolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShape = "Polygon";
        }
        private void EllipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShape = "Ellips";
        }

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
                    settingShape.StrokeColor = colorDialog.Color; 
                    ColorButton.BackColor = colorDialog.Color;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    settingShape.FillColor = colorDialog.Color;
                    buttonFillColor.BackColor = colorDialog.Color;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            settingShape.Width = trackBar1.Value;
        }
        private void AddShapeToMenu(ShapeType type, string name)
        {
            var item = new ToolStripMenuItem(name);
            item.Tag = type; 
             // item.Image = icon;
            //item.Click += ShapeMenuItem_Click;
            contextMenuStripBaseFigure.Items.Add(item);
        }
        private void addPlugin_Click(object sender, EventArgs e)
        {
            AddShapeToMenu(ShapeType.Line, "shmakadyvka");
        }

        private void buttonUNDO_Click(object sender, EventArgs e)
        {
            undoRedoShapes.Undo();
            pictureBox1.Invalidate();
        }

        private void buttonREDO_Click(object sender, EventArgs e)
        {
            undoRedoShapes.Redo();
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
