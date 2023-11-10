using Generator.Models;
using Generator.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aa
{

           
            //builder.AppendLine($"public static partial class {classInfo.Name} 
            //{
            ////builder.AppendLine($"public static class Comparator {{

            ////builder.AppendLine($"public Dictionary<string, object> Compare<{classInfo.Name}(this {classInfo.Name} obj1, {classInfo.Name} obj2)
            //builder.AppendLine($"public static Dictionary<string, object> Compare(this {classInfo.Name} obj1, {classInfo.Name} obj2)
            ////builder.AppendLine($"public static Dictionary<string, object> Compare<{classInfo.Name}({classInfo.Name} obj1, {classInfo.Name} obj2)
            //{
            //builder.AppendLine($"var propertyDifferences = new Dictionary<string, object>();
            //builder.AppendLine($"if (obj1 != null && obj2 != null)
            //{
            //foreach (var parameter in classInfo.Fields)
            //{
            //    builder.AppendLine($"if (!object.Equals(obj1.{ parameter.Name}, obj2.{parameter.Name}))
            //    {
            //    builder.AppendLine($"propertyDifferences[\"\"{parameter.Name}\"\"] = obj1.{parameter.Name};
            //    }
            //}
            //builder.AppendLine($"return propertyDifferences;
            //}
            //}

}
