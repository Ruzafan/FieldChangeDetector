using System.Reflection;

namespace RoslynComparatorGenerator
{
    public class RoslynCodeGenerator
    {
        public static string GenerateComparisonCode<T>() where T : class
        {
            var propertyDeclarations = typeof(T).GetProperties();

            // Generate code to compare properties and populate the dictionary
            var code = $@"
        namespace RoslynComparer
        {{
            public class ComparisonHelper
            {{
                public Dictionary<string, object> ReturnDiferentFieldsRoslyn({typeof(T).FullName} obj1, {typeof(T).FullName} obj2)
                {{
                    var propertyDifferences = new Dictionary<string, object>();
                    if (obj1 != null && obj2 != null)
                    {{
                        {string.Join(Environment.NewLine, propertyDeclarations.Select(GeneratePropertyComparison))}
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