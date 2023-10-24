using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Reflection;
using System.Text;

namespace FieldsChangeDetector
{
    class Compiler
    {
        public Assembly CompileCode(string code)
    {

            // Set up compilation Configuration
            var tree = SyntaxFactory.ParseSyntaxTree(code.Trim());
            var compilation = CSharpCompilation.Create("Executor.cs")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
                    optimizationLevel: OptimizationLevel.Release))
                .AddSyntaxTrees(tree);

            string errorMessage = null;
            Assembly assembly = null;

            bool isFileAssembly = false;
            Stream codeStream = null;
            using (codeStream = new MemoryStream())
            {
                // Actually compile the code
                EmitResult compilationResult = null;
                compilationResult = compilation.Emit(codeStream);

                // Compilation Error handling
                if (!compilationResult.Success)
                {
                    var sb = new StringBuilder();
                    foreach (var diag in compilationResult.Diagnostics)
                    {
                        sb.AppendLine(diag.ToString());
                    }
                    errorMessage = sb.ToString();


                    return null;
                }

                // Load
                return Assembly.Load(((MemoryStream)codeStream).ToArray());
            }
        }

    }
}
