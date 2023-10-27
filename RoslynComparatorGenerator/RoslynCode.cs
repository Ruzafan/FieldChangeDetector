using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RoslynComparatorGenerator
{
    public class RoslynCode
    {
        public static string GenerateComparisonCode<T>() where T : class
        {
            var propertyDeclarations = typeof(T).GetProperties();

            // Generate code to compare properties and populate the dictionary
            var code = $@"
            using System.Text;
using System.Reflection;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
            namespace RoslynComparer
        {{
            public class ComparisonHelper
            {{
                public Dictionary<string, object> Compare{typeof(T).Name}({typeof(T).FullName} obj1, {typeof(T).FullName} obj2)
                {{
                    var propertyDifferences = new Dictionary<string, object>();
                    if (obj1 != null && obj2 != null)
                    {{
                        {string.Join("\n", propertyDeclarations.Select(GeneratePropertyComparison))}
                    }}
                    return propertyDifferences;
                }}
            }}
        }}
        ";
            return code;
        }

        private static string GeneratePropertyComparison(PropertyInfo property)
        {
            return $@"
            if (!object.Equals(obj1.{property.Name}, obj2.{property.Name}))
            {{
                propertyDifferences[""{property.Name}""] = obj1.{property.Name};
            }}
        ";
        }


    }
}
