using System.Text;
using ChangeDetectableCodeGenerator.Models;

namespace ChangeDetectableCodeGenerator
{
    public class FieldComparatorTemplate
    {
        public string GetClassSource(ClassInfo classInfo)
        {
            StringBuilder builder = new StringBuilder();
            //builder.AppendLine();
            //foreach (var usingStatement in classInfo.Usings)
            //{
            //    builder.AppendLine(usingStatement);
            //}
            //builder.AppendLine();
            builder.AppendLine($"namespace {classInfo.Namespace}");
            builder.AppendLine("{");
                builder.AppendLine($"public static class {classInfo.Name}Extensions ");
                    builder.AppendLine("{");

                        builder.AppendLine($"public static Dictionary<string, object> DetectChanges(this {classInfo.Name} obj1, {classInfo.Name} obj2)");
                        builder.AppendLine("{");
                            builder.AppendLine($"var propertyDifferences = new Dictionary<string, object>();");
                            builder.AppendLine($"if (obj1 != null && obj2 != null)");
                            builder.AppendLine("{");
                                foreach (var parameter in classInfo.Fields)
                                {
                                    builder.AppendLine($"if (!object.Equals(obj1.{parameter.Name}, obj2.{parameter.Name}))");
                                    builder.AppendLine("{");
                                    builder.AppendLine($"propertyDifferences[\"{parameter.Name}\"] = obj2.{parameter.Name};");
                                    builder.AppendLine("}");
                                }
                            builder.AppendLine("}");
                            builder.AppendLine($"return propertyDifferences;");
                        builder.AppendLine("}");
                builder.AppendLine("}");
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
