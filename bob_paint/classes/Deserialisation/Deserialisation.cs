using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.IO;
using bob_paint.classes.settings;
using bob_paint;


namespace bob_paint.classes.Serialisation
{
    internal class Deserilization
    {

        private Dictionary<string, Func<BaseShape>> shapeFactory;
        private SettingsTempShape settingShape;
        public Deserilization(Dictionary<string, Func<BaseShape>> shapeFactory, SettingsTempShape settingShape)
        {
            this.shapeFactory = shapeFactory;
            this.settingShape = settingShape;
            var a = 1;
        }

        public List<BaseShape> LoadShapesFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var jArray = JArray.Parse(json);
            var loadedShapes = new List<BaseShape>();

            foreach (var item in jArray)
            {
                var shape = CreateShapeFromJson(item);
                if (shape != null)
                {
                    loadedShapes.Add(shape);
                }
            }
            return loadedShapes;
        }

        private BaseShape CreateShapeFromJson(JToken item)
        {
            string type = item["Type"]?.ToString();
            if (string.IsNullOrEmpty(type))
            {
                Console.WriteLine("Тип фигуры не указан");
                return null;
            }

            ApplyShapeProperties(item);
            var shape = shapeFactory[type]();
            return shapeFactory[type]();
        }

        private void ApplyShapeProperties(JToken item)
        {

            settingShape.startPosition = new Point(
                item["StartX"]?.ToObject<int>() ?? 0,
                item["StartY"]?.ToObject<int>() ?? 0
            );

            settingShape.endPosition = new Point(
                item["EndX"]?.ToObject<int>() ?? 0,
                item["EndY"]?.ToObject<int>() ?? 0
            );

            settingShape.StrokeColor = ParseJsonColor(item["StrokeColor"] ?? item["ColorLine"], Color.Black);

            settingShape.FillColor = ParseJsonColor(item["FillColor"], Color.Transparent);
            settingShape.Width = item["Width"]?.ToObject<int>() ?? 1;

            if (item["Points"] != null)
            {
                settingShape.currentBrokenLinePoints = ParsePoints(item["Points"].ToString());
            }

            if (item["Nlines"] != null)
            {
                settingShape.CountOfAngle = item["Nlines"].ToObject<int>();
            }
        }

        private List<Point> ParsePoints(string pointsJson)
        {
            return JsonConvert.DeserializeObject<List<string>>(pointsJson)
                .Select(coord =>
                {
                    var parts = coord.Split(',');
                    if (parts.Length == 2 &&
                        int.TryParse(parts[0].Trim(), out int x) &&
                        int.TryParse(parts[1].Trim(), out int y))
                    {
                        return new Point(x, y);
                    }
                    return (Point?)null;
                })
                .Where(p => p.HasValue)
                .Select(p => p.Value)
                .ToList();
        }

        private Color ParseJsonColor(JToken colorToken, Color defaultColor)
        {
            if (colorToken == null)
                return defaultColor;

            switch (colorToken.Type)
            {
                case JTokenType.String:
                    Color namedColor = Color.FromName(colorToken.ToString());
                    return namedColor.A != 0 ? namedColor : defaultColor;

                case JTokenType.Integer:
                    return Color.FromArgb(colorToken.ToObject<int>());

                default:
                    return defaultColor;
            }
        }
    }

}