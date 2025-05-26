using bob_paint;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bob_paint.classes.Serialization
{
    internal class Serialisation
    {
        public bool SaveShapesToJson(List<BaseShape> shapes, string path)
        {
            try
            {
                var shapesData = shapes.Select(shape =>
                {
                    dynamic obj = new System.Dynamic.ExpandoObject();
                    obj.Type = shape.GetType().Name;

                    // Автоматически собираем все свойства с атрибутом JsonProperty
                    var properties = shape.GetType()
                        .GetProperties()
                        .Where(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Any());

                    foreach (var prop in properties)
                    {
                        ((IDictionary<string, object>)obj)[prop.Name] = prop.GetValue(shape);
                    }

                    return obj;
                }).ToList();

                string jsonData = JsonConvert.SerializeObject(shapesData, Formatting.Indented);
                File.WriteAllText(path, jsonData);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}