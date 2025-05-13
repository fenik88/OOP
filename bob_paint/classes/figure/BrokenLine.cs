using System.Collections.Generic;
using System.Drawing;

namespace bob_paint.classes.figure
{
    internal class BrokenLine : LineShape
    {
        protected List<Point> points;

        public BrokenLine(List<Point> ps, Color colorL, float widthL)
            : base(ps.Count > 0 ? ps[0] : Point.Empty,
                  ps.Count > 1 ? ps[1] : Point.Empty,
                  colorL, widthL)
        {
            points = new List<Point>(ps); // Создаем копию списка
        }

        public override void Draw(Graphics graphics)
        {
            if (points.Count < 2) return;

            // Используем базовый функционал LineShape для рисования каждого отрезка
            for (int i = 0; i < points.Count - 1; i++)
            {
                startPosition = points[i];
                endPosition = points[i + 1];
                base.Draw(graphics); // Вызываем базовый метод рисования линии
            }
        }

        // Добавляем метод для добавления новой точки
        public void AddPoint(Point newPoint)
        {
            points.Add(newPoint);
        }

        // Метод для очистки точек
        public void ClearPoints()
        {
            points.Clear();
        }

        // Свойство для получения количества точек
        public int PointCount => points.Count;
    }
}