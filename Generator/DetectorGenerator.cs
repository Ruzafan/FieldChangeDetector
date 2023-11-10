using Generator.Mappers;
using Generator.Models;
using Microsoft.CodeAnalysis;

namespace Generator
{
    [Generator]
    public class DetectorGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var reciever = context.SyntaxContextReceiver as SyntaxCollector<ClassInfo>;
            var template = new FieldComparatorTemplate();
            foreach (var classInfo in reciever.Items)
            {
                context.AddSource($"{classInfo.Namespace}.{classInfo.Name}.g.cs", template.GetClassSource(classInfo));
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxCollector<ClassInfo>(new FactoryComparatorClassInfoMapper()));
        }
    }
}
