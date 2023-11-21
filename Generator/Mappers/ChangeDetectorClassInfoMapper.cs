using ChangeDetectableCodeGenerator.Models;
using ChangeDetectableCodeGenerator.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Linq;

namespace ChangeDetectableCodeGenerator.Mappers
{
    public class ChangeDetectorClassInfoMapper : ISyntaxMapper<ClassInfo>
    {
        public ClassInfo MapClassInfo(SyntaxNode syntaxNode, SemanticModel semanticModel)
        {
            // Find all classes with fields with a [ChangeDetectable] attribute
            if (syntaxNode is ClassDeclarationSyntax classDeclaration)
            {
                //if (!Debugger.IsAttached) Debugger.Launch();
                var fields = classDeclaration.Members.Where(q=> q is PropertyDeclarationSyntax)
                    .Cast<PropertyDeclarationSyntax>()
                    .Where(q=> HasChangeDetectableAttribute(q) || HasMongoChangeDetectableAttribute(q) )
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
                        Name = classDeclaration.Identifier.ToString(),
                        AttributeType = fields.Any(q=>q.IsMongo) ? FieldComparatorType.Mongo : FieldComparatorType.Generic
                    };

                    return classInfo;
                }
            }

            return null;
        }
        private bool HasChangeDetectableAttribute(PropertyDeclarationSyntax fieldDeclaration)
        {
            return fieldDeclaration.AttributeLists.HasAttribute("ChangeDetectable");
        }

        private bool HasMongoChangeDetectableAttribute(PropertyDeclarationSyntax fieldDeclaration)
        {
            return fieldDeclaration.AttributeLists.HasAttribute("MongoChangeDetectable");
        }

        private FieldInfo MapToFieldInfo(PropertyDeclarationSyntax fieldDeclaration)
        {
           // if (!Debugger.IsAttached) Debugger.Launch();
            return new FieldInfo
            {
                Name = fieldDeclaration.Identifier.ToString(),
                Type = fieldDeclaration.Type.ToFullString(),
                IsGeneric = HasChangeDetectableAttribute(fieldDeclaration),
                IsMongo = HasMongoChangeDetectableAttribute(fieldDeclaration)
            };
        }

        public ClassInfo MapSyntax(SyntaxNode syntaxNode, SemanticModel semanticModel)
        {
            return MapClassInfo(syntaxNode, semanticModel);
        }
    }
}
