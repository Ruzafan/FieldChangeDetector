using System.Text;
using Generator.Models;

namespace Generator
{
    public class FieldComparatorTemplate
    {
        public string GetClassSource(ClassInfo classInfo)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            foreach (var usingStatement in classInfo.Usings)
            {
                builder.AppendLine(usingStatement);
            }
            builder.AppendLine();
            builder.AppendLine($"namespace {classInfo.Namespace}");
            builder.AppendLine($"{{");
           
            builder.AppendLine($"public static partial class {classInfo.Name} ");
            builder.AppendLine($"{{");
            //builder.AppendLine($"public static class Comparator {{");

            //builder.AppendLine($"public Dictionary<string, object> Compare<{classInfo.Name}(this {classInfo.Name} obj1, {classInfo.Name} obj2)");
            builder.AppendLine($"public static Dictionary<string, object> Compare(this {classInfo.Name} obj1, {classInfo.Name} obj2)");
            //builder.AppendLine($"public static Dictionary<string, object> Compare<{classInfo.Name}({classInfo.Name} obj1, {classInfo.Name} obj2)");
            builder.AppendLine($"{{");
            builder.AppendLine($"var propertyDifferences = new Dictionary<string, object>();");
            builder.AppendLine($"if (obj1 != null && obj2 != null)");
            builder.AppendLine($"{{");
            foreach (var parameter in classInfo.Fields)
            {
                builder.AppendLine($"if (!object.Equals(obj1.{ parameter.Name}, obj2.{parameter.Name}))");
                builder.AppendLine($"{{");
                builder.AppendLine($"propertyDifferences[\"\"{parameter.Name}\"\"] = obj1.{parameter.Name};");
                builder.AppendLine($"}}");
            }
            builder.AppendLine($"return propertyDifferences;");
            builder.AppendLine($"}}");
            builder.AppendLine($"}}");
            builder.AppendLine($"}}");
            return builder.ToString();
        }
    }
}
