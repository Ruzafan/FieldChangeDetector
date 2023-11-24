using ChangeDetectableCodeGenerator.Models;
using System.Text;

namespace ChangeDetectableCodeGenerator
{
    public class FieldComparatorTemplate
    {
        public string GetClassSource(ClassInfo classInfo)
        {
            //if(!Debugger.IsAttached) Debugger.Launch();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            foreach (var usingStatement in classInfo.Usings)
            {
                builder.AppendLine(usingStatement);
            }
            builder.AppendLine();
            builder.AppendLine($"namespace {classInfo.Namespace}");
            builder.AppendLine("{");
            builder.AppendLine($"public static class {classInfo.Name}Extensions ");
            builder.AppendLine("{");

            switch (classInfo.AttributeType)
            {
                case FieldComparatorType.Generic: AddGenericMethod(classInfo, builder); break;
                case FieldComparatorType.Mongo: AddMongoMethod(classInfo, builder); break;
            }


            // builder.AppendLine($"public static string GetMongoUpdateDefinitionOfDifferences(this {classInfo.Name} obj1, {classInfo.Name} obj2)");
            //builder.AppendLine("{");
            //    builder.AppendLine("var propertyDifferences = \" { $set: { \"; ");
            //    builder.AppendLine($"if (obj1 != null && obj2 != null)");
            //    builder.AppendLine("{");
            //    foreach (var parameter in classInfo.Fields)
            //    {
            //        builder.AppendLine($"if (!object.Equals(obj1.{parameter.Name}, obj2.{parameter.Name}))");
            //        builder.AppendLine("{");
            //        builder.AppendLine($"propertyDifferences += \" {parameter.Name}: obj2.{parameter.Name} \" ;");
            //        builder.AppendLine("}");
            //    }
            //    builder.AppendLine("}");
            //    builder.AppendLine("propertyDifferences += \" } }\";");
            //    builder.AppendLine($"return propertyDifferences;");
            //builder.AppendLine("}");

            builder.AppendLine("}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        private static void AddMongoMethod(ClassInfo classInfo, StringBuilder builder)
        {
            builder.AppendLine($"public static UpdateDefinition<{classInfo.Name}> GetMongoUpdateDefinitionOfDifferences(this {classInfo.Name} obj1, {classInfo.Name} obj2)");
            builder.AppendLine("{");
            builder.AppendLine($"var updateDefinition = new List<UpdateDefinition<{classInfo.Name}>>();");
            builder.AppendLine($"if (obj1 != null && obj2 != null)");
            builder.AppendLine("{");
            foreach (var parameter in classInfo.Fields)
            {
                builder.AppendLine($"if (!object.Equals(obj1.{parameter.Name}, obj2.{parameter.Name}))");
                builder.AppendLine("{");
                builder.AppendLine($"updateDefinition.Add(Builders<{classInfo.Name}>.Update.Set(q => q.{parameter.Name}, obj2.{parameter.Name}));");
                builder.AppendLine("}");
            }
            builder.AppendLine("}");
            builder.AppendLine($"return Builders<{classInfo.Name}>.Update.Combine(updateDefinition);");
            builder.AppendLine("}");
        }

        private static void AddGenericMethod(ClassInfo classInfo, StringBuilder builder)
        {
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
        }
    }
}
