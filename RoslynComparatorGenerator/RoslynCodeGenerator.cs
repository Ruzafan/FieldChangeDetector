using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Reflection;
using System.Text;

namespace RoslynComparatorGenerator
{
    [Generator]
    public class RoslynCodeGenerator : ISourceGenerator
    {

        //private static string GeneratePropertyComparison(PropertyInfo property)
        //{
        //    return $@"
        //    if (!object.Equals(obj1.{property.Name}, obj2.{property.Name}))
        //    {
        //        propertyDifferences[""{property.Name}""] = obj1.{property.Name};
        //    }
        //";
        //}

        public void Execute(GeneratorExecutionContext context)
        {
            var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken);

            var sourceBuilder = new StringBuilder(@"
        namespace RoslynComparer
        {
            public static class ComparisonHelper
            {
                public Dictionary<string, object> ReturnDiferentFieldsRoslyn<T>(typeof(T).FullName obj1, typeof(T).FullName obj2)
                {
                    var propertyDifferences = new Dictionary<string, object>();
                    if (obj1 != null && obj2 != null)
                    {
                        {string.Join(Environment.NewLine, propertyDeclarations.Select(GeneratePropertyComparison))}
                    }
                    return propertyDifferences;
                }

                private static string GeneratePropertyComparison(PropertyInfo property)
                {
                    return
                    if (!object.Equals(obj1.{property.Name}, obj2.{property.Name}))
                    {
                        propertyDifferences[""{property.Name}""] = obj1.{property.Name};
                    }
                }
            }
        }
    ");
            var typeName = mainMethod.ContainingType.Name;
            context.AddSource($"{typeName}.g.cs", sourceBuilder.ToString());
            //context.AddSource("RoslynCodeGenerator", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required for this one
        }
    }
}