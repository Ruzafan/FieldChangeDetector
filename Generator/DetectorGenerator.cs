using ChangeDetectableCodeGenerator.Mappers;
using ChangeDetectableCodeGenerator.Models;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace ChangeDetectableCodeGenerator
{
    [Generator]
    public class ChangeDetectableGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            //if (!Debugger.IsAttached) Debugger.Launch();
            var reciever = context.SyntaxContextReceiver as SyntaxCollector<ClassInfo>;
            var template = new FieldComparatorTemplate();
            foreach (var classInfo in reciever.Items)
            {
                context.AddSource($"{classInfo.Namespace}.{classInfo.Name}Extensions.g.cs", template.GetClassSource(classInfo));
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxCollector<ClassInfo>(new ChangeDetectorClassInfoMapper()));
        }
    }
}
