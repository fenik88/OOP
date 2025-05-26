using bob_paint;
using bob_paint.classes.figure;
using bob_paint.classes.lists;
using bob_paint.classes.Serialisation;
using bob_paint.classes.Serialization;
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
            settingShape.CountOfAngle = 5;
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
            shapes = undoRedoShapes.shapes;
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
                settingShape.currentBrokenLinePoints.Clear();

                selectedShapeKey = key;
                ShapeButton.Image = menuItem.Image;
            }
        }

        private void AddPlugin(Type shapeType)
        {
            string key = shapeType.Name;


            if (shapeKeys.Contains(key))
                return;

            shapeKeys.Add(key);

            shapeFactory[key] = () =>
            {
                try
                {

                    return (BaseShape)Activator.CreateInstance(
                        shapeType,
                        settingShape.startPosition,
                        settingShape.endPosition,
                        settingShape.StrokeColor,
                        settingShape.Width,
                        settingShape.FillColor
                    );
                }
                catch
                {

                    try
                    {
                        var shape = (BaseShape)Activator.CreateInstance(shapeType);

                        shape.GetType().GetProperty("StartX")?.SetValue(shape, settingShape.startPosition.X);
                        shape.GetType().GetProperty("StartY")?.SetValue(shape, settingShape.startPosition.Y);
                        shape.GetType().GetProperty("EndX")?.SetValue(shape, settingShape.endPosition.X);
                        shape.GetType().GetProperty("EndY")?.SetValue(shape, settingShape.endPosition.Y);

                        var strokeProp = shape.GetType().GetProperty("ColorLine");
                        strokeProp?.SetValue(shape, settingShape.StrokeColor);

                        var widthProp = shape.GetType().GetProperty("WidthLine");
                        widthProp?.SetValue(shape, settingShape.Width);

                        var fillProp = shape.GetType().GetProperty("FillColor");
                        fillProp?.SetValue(shape, settingShape.FillColor);

                        return shape;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка создания фигуры {key}: {ex.Message}");
                        return null;
                    }
                }
            };

            AddShape(key, key, Properties.Resources.Undefine, shapeFactory[key]);

            if (!shapeKeys.Contains(key))
                shapeKeys.Add(key);

            shapeFactory[key] = () => (BaseShape)Activator.CreateInstance(
                shapeType,
                settingShape.startPosition,
                settingShape.endPosition,
                settingShape.StrokeColor,
                settingShape.Width,
                settingShape.FillColor
            );

            var menuItem = new ToolStripMenuItem(key)
            {
                Tag = key,
                Image = (System.Drawing.Image)Properties.Resources.Undefine
            };
            menuItem.Click += ShapeMenuItem_Click;

        }



        private void LoadPlugins()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DLL файлы (*.dll)|*.dll";
                openFileDialog.Title = "Выберите плагин";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dllPath = openFileDialog.FileName;

                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(dllPath);

                        int found = 0;
                        foreach (Type type in assembly.GetTypes())
                        {
                            if (type.IsSubclassOf(typeof(BaseShape)) && !type.IsAbstract)
                            {
                                AddPlugin(type);
                                found++;
                            }
                        }

                        if (found == 0)
                        {
                            MessageBox.Show("В выбранном файле не найдено подходящих плагинов.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Загружено плагинов: {found}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки плагина:\n{ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Сохранить фигуры";
                saveFileDialog.DefaultExt = "json";
                saveFileDialog.FileName = "shapes.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Serialisation serialization = new Serialisation();
                    if (serialization.SaveShapesToJson(shapes, saveFileDialog.FileName))
                    {
                        MessageBox.Show("Фигуры успешно сохранены!");
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при сохранении");
                    }
                }

            }

        }

        private void LoadShapes_Click(object sender, EventArgs e)
        {

            using (var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                Title = "Открыть файл с фигурами",
                DefaultExt = "json",
                FileName = "shapes.json"
            })
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    Deserilization deserilization = new Deserilization(shapeFactory, settingShape);
                    var shapes = deserilization.LoadShapesFromJson(openFileDialog.FileName);

                    undoRedoShapes.shapes = shapes;
                    this.shapes = shapes;
                    Canvas.Invalidate();

                    MessageBox.Show("Фигуры успешно загружены!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
           LoadPlugins();
        }
    }
}
