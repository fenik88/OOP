using bob_paint;
using bob_paint.classes.figure;
using bob_paint.classes.lists;
using bob_paint.classes.settings;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace bob_paint
{
    public partial class Form1 : Form
    {
        private List<baseShape> shapes;

        private settingsTempShape settingShape = new settingsTempShape();

        private UndoRedoShapes undoRedoShapes = new UndoRedoShapes();

        private List<string> shapeKeys = new List<string>(); 

        private int CountOfAngle = 5;

        private List<Point> currentBrokenLinePoints = new List<Point> { };

        private Dictionary<string, Func<baseShape>> shapeFactory = new Dictionary<string, Func<baseShape>>();
        private string selectedShapeKey;

        public Form1()
        {
            InitializeComponent();
            InitializeDefaultShapes();
            shapes = new List<baseShape> { };

            settingShape.FillColor = Color.FromArgb(255, 255, 255, 255);
            contextMenuStripBaseFigure.ImageScalingSize = new Size(32, 32);
            ShapeButton.ContextMenuStrip = contextMenuStripBaseFigure;
           

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CountOfAngle = 5;
            ColorButton.BackColor = Color.Black;
        }

        private void AddShape(string key, string name, Image icon, Func<baseShape> factory)
        {
            if (!shapeKeys.Contains(key))
                shapeKeys.Add(key);

            shapeFactory[key] = factory;

            var menuItem = new ToolStripMenuItem(name)
            {
                Tag = key,
                Image = icon
            };
            menuItem.Click += ShapeMenuItem_Click;
            contextMenuStripBaseFigure.Items.Add(menuItem);
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            shapes = undoRedoShapes.Shapes;
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }

            if (settingShape.isDrawing && selectedShapeKey != null)
            {
                baseShape temporaryShape = null;
                currentBrokenLinePoints.Add(settingShape.endPosition);
                temporaryShape = shapeFactory[selectedShapeKey]();
                currentBrokenLinePoints.Remove(settingShape.endPosition);
                if (temporaryShape != null)
                {
                    temporaryShape.Draw(e.Graphics);
                }
            }

           
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                settingShape.startPosition = e.Location;
                settingShape.isDrawing = true;
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (settingShape.isDrawing)
            {
                settingShape.endPosition = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && settingShape.isDrawing)
            {
                if (selectedShapeKey == "BrokenLine")
                {
                    currentBrokenLinePoints.Add(e.Location);
                    pictureBox1.Invalidate();
                }
                else
                {

                    settingShape.endPosition = e.Location;
                    baseShape temporaryShape = shapeFactory[selectedShapeKey]();
                    if (temporaryShape != null)
                    {
                        undoRedoShapes.AddShape(temporaryShape);
                    }
                    settingShape.isDrawing = false;
                    pictureBox1.Invalidate();
                }
            }
        }


        private void ShapeMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is string key)
            {
                selectedShapeKey = key;
                ShapeButton.Image = menuItem.Image;
            }
        }
       

        // нужно реализовать добавление плагина
        private void AddPlugin(Type shapeType)
        {
            string key = shapeType.Name;

            if (!shapeKeys.Contains(key))
                shapeKeys.Add(key);

            shapeFactory[key] = () => (baseShape)Activator.CreateInstance(
                shapeType,
                settingShape.startPosition,
                settingShape.endPosition,
                settingShape.StrokeColor,
                settingShape.Width,
                settingShape.FillColor
            );
            Tag = key;
            Image tempImage = (System.Drawing.Image)Properties.Resources.Undefine;

            AddShape(key, key, tempImage, shapeFactory[key]);

        }


  
        private void InitializeDefaultShapes()
        {
            AddShape(
                key: "Line",
                name: "Line",
                icon: Properties.Resources.Line,
                factory: () => new LineShape(settingShape.startPosition, settingShape.endPosition, settingShape.StrokeColor, settingShape.Width)
            );

            AddShape(
                key: "Rectangle",
                name: "Rectangle",
                icon: Properties.Resources.Rectangle,
                factory: () => new RectangleShape(settingShape.startPosition, settingShape.endPosition, settingShape.StrokeColor, settingShape.Width, settingShape.FillColor)
            );

            AddShape(
                key: "Ellips",
                name: "Ellips",
                icon: Properties.Resources.Ellips,
                factory: () => new EllipsShape(settingShape.startPosition, settingShape.endPosition, settingShape.StrokeColor, settingShape.Width, settingShape.FillColor)
            );

            AddShape(
                key: "Polygon",
                name: "Polygon",
                icon: Properties.Resources.Polygon,
                factory: () => new Polygon(settingShape.startPosition, settingShape.endPosition, settingShape.StrokeColor, settingShape.Width, settingShape.FillColor, CountOfAngle)
            );

            AddShape(
                key: "BrokenLine",
                name: "BrokenLine",
                icon: Properties.Resources.BrokenLine,
                factory: () => new BrokenLine(currentBrokenLinePoints, settingShape.StrokeColor, settingShape.Width)
            );
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            settingShape.Width = trackBar1.Value;
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
        private void ShapeButton_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                Point location = new Point(ShapeButton.Left + ShapeButton.Width, ShapeButton.Top);
                ShapeButton.ContextMenuStrip.Show(ShapeButton, location);
            }
        }

        // нужно реализовать сохранение и загрузку и переименовать кнопки
        private void button1_Click_1(object sender, EventArgs e)
        {
          //  undoRedoShapes.SaveShapes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // undoRedoShapes.LoadShapes();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (selectedShapeKey == "BrokenLine" && currentBrokenLinePoints.Count >= 2)
            {
                var brokenLine = new BrokenLine(new List<Point>(currentBrokenLinePoints),
                                              settingShape.StrokeColor,
                                              settingShape.Width);
                undoRedoShapes.AddShape(brokenLine);
                currentBrokenLinePoints.Clear();
                settingShape.isDrawing = false;
                pictureBox1.Invalidate();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            CountOfAngle = trackBar2.Value;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStripUP_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStripUP_FILE_Click(object sender, EventArgs e)
        {

        }

        private void ShapeButton_Click(object sender, EventArgs e)
        {

        }

        private void add_plugin_Click(object sender, EventArgs e)
        {
           //AddPlugin();
        }
    }
}
