using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Controls.Shapes;

namespace lab_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Инициализируем окно
            Width = 400;
            Height = 400;
            Title = "Shapes in Avalonia";

            // Создаём холст
            var canvas = new Canvas();

            // Отрезок
            var line = new Line
            {
                StartPoint = new Avalonia.Point(10, 10),
                EndPoint = new Avalonia.Point(100, 100),
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            // Прямоугольник
            var rect = new Rectangle
            {
                Width = 100,
                Height = 50,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };
            Canvas.SetLeft(rect, 50);
            Canvas.SetTop(rect, 50);

            // Эллипс
            var ellipse = new Ellipse
            {
                Width = 80,
                Height = 50,
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };
            Canvas.SetLeft(ellipse, 150);
            Canvas.SetTop(ellipse, 150);

            // Многоугольник
            var polygon = new Polygon
            {
                Points = new Avalonia.Point[] { new(200, 200), new(250, 250), new(300, 200) },
                Stroke = Brushes.Green,
                StrokeThickness = 2
            };

            // Ломаная
            var polyline = new Polyline
            {
                Points = new Avalonia.Point[] { new(50, 300), new(100, 350), new(150, 300), new(200, 350) },
                Stroke = Brushes.Purple,
                StrokeThickness = 2
            };

            // Добавляем фигуры в холст
            canvas.Children.Add(line);
            canvas.Children.Add(rect);
            canvas.Children.Add(ellipse);
            canvas.Children.Add(polygon);
            canvas.Children.Add(polyline);

            // Устанавливаем холст как содержимое окна
            Content = canvas;
        }
    }
}
