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
    public partial class MyPaint : Form
    {
        private List<BaseShape> shapes;

        private SettingsTempShape settingShape = new SettingsTempShape();

        private UndoRedoShapes undoRedoShapes = new UndoRedoShapes();

        private List<string> shapeKeys = new List<string>(); 

        private int CountOfAngle = 5;

        private List<Point> currentBrokenLinePoints = new List<Point> { };

        private Dictionary<string, Func<BaseShape>> shapeFactory = new Dictionary<string, Func<BaseShape>>();
        private string selectedShapeKey;

        public MyPaint()
        {
            InitializeComponent();
            InitializeDefaultShapes();
            shapes = new List<BaseShape> { };

            settingShape.FillColor = Color.FromArgb(255, 255, 255, 255);
            contextMenuStripBaseFigure.ImageScalingSize = new Size(32, 32);
            ShapeButton.ContextMenuStrip = contextMenuStripBaseFigure;
           

        }
        private void MyPaint_Load(object sender, EventArgs e)
        {
                CountOfAngle = 5;
            ColorButton.BackColor = Color.Black;
        }

        private void AddShape(string key, string name, Image icon, Func<BaseShape> factory)
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


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            shapes = undoRedoShapes.Shapes;
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }

            if (settingShape.isDrawing && selectedShapeKey != null)
            {
                BaseShape temporaryShape = null;
                settingShape.currentBrokenLinePoints.Add(settingShape.endPosition);
                temporaryShape = shapeFactory[selectedShapeKey]();
                settingShape.currentBrokenLinePoints.Remove(settingShape.endPosition);
                if (temporaryShape != null)
                {
                    temporaryShape.Draw(e.Graphics);
                }
            }

           
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                settingShape.startPosition = e.Location;
                settingShape.isDrawing = true;
            }

        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (settingShape.isDrawing)
            {
                settingShape.endPosition = e.Location;
                Canvas.Invalidate();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && settingShape.isDrawing)
            {
                settingShape.currentBrokenLinePoints.Add(e.Location);
                settingShape.endPosition = e.Location;

                try
                {
                    BaseShape temporaryShape = shapeFactory[selectedShapeKey]();


                    if (temporaryShape != null)
                    {
                        undoRedoShapes.AddShape(temporaryShape);
                    }
                    settingShape.isDrawing = false;
                    Canvas.Invalidate();
                }
                catch
                {

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
                factory: () => new BrokenLine(settingShape.currentBrokenLinePoints, settingShape.StrokeColor, settingShape.Width)
            );
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            settingShape.Width = trackBar1.Value;
        }

        private void ButtonUNDO_Click(object sender, EventArgs e)
        {
            undoRedoShapes.Undo();
            Canvas.Invalidate();
        }

        private void ButtonREDO_Click(object sender, EventArgs e)
        {
            undoRedoShapes.Redo();
            Canvas.Invalidate();
        }

        private void FillColor_Click(object sender, EventArgs e)
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
        private void SaveShapes_Click_1(object sender, EventArgs e)
        {
          //  undoRedoShapes.SaveShapes();
        }

        private void LoadShapes_Click(object sender, EventArgs e)
        {
           // undoRedoShapes.LoadShapes();
        }

        private void Canvas_DoubleClick(object sender, EventArgs e)
        {
            if (settingShape.currentBrokenLinePoints.Count >= 2)
            {
                var brokenLine = new BrokenLine(new List<Point>(settingShape.currentBrokenLinePoints),
                                              settingShape.StrokeColor,
                                              settingShape.Width);
                undoRedoShapes.AddShape(brokenLine);
                settingShape.currentBrokenLinePoints.Clear();
                settingShape.isDrawing = false;
                Canvas.Invalidate();
            }
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            CountOfAngle = trackBar2.Value;
        }


        private void Add_plugin_Click(object sender, EventArgs e)
        {
           //AddPlugin();
        }
    }
}
