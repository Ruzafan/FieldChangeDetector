using Generator.Models;
using Generator.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace Generator.Mappers
{
    public class FactoryComparatorClassInfoMapper : ISyntaxMapper<ClassInfo>
    {
        public ClassInfo MapClassInfo(SyntaxNode syntaxNode, SemanticModel semanticModel)
        {
            // Find all classes with fields with a [Comparable] attribute
            if (syntaxNode is ClassDeclarationSyntax classDeclaration)
            {

                var fields = classDeclaration.Members.OfType<FieldDeclarationSyntax>()
                    .Where(HasComparableAttribute)
                    .Select(MapToFieldInfo)
                    .ToArray();

                if (fields.Any())
                {
                    var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);

                    var classInfo = new ClassInfo()
                    {
                        Usings = classDeclaration.GetUsingStatements().Select((us) => us.ToFullString()).ToArray(),
                        Namespace = classSymbol?.ContainingNamespace.ToString(),
                        Fields = fields.ToArray(),
                        Name = classDeclaration.Identifier.ToString()
                    };

                    return classInfo;
                }
            }

            return null;
        }
        private bool HasComparableAttribute(FieldDeclarationSyntax fieldDeclaration)
        {
            return fieldDeclaration.AttributeLists.HasAttribute("Comparable");
        }
        private FieldInfo MapToFieldInfo(FieldDeclarationSyntax fieldDeclaration)
        {
            return new FieldInfo
            {
                Name = fieldDeclaration.Declaration.Variables.First().Identifier.ToString(),
                Type = fieldDeclaration.Declaration.Type.ToFullString(),
            };
        }

        public ClassInfo MapSyntax(SyntaxNode syntaxNode, SemanticModel semanticModel)
        {
            return MapClassInfo(syntaxNode, semanticModel);
        }
    }
}
