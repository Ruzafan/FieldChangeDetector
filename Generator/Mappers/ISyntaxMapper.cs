using Microsoft.CodeAnalysis;

namespace ChangeDetectableCodeGenerator.Mappers
{
    public interface ISyntaxMapper<TResult>
    {

        TResult MapSyntax(SyntaxNode syntaxNode, SemanticModel semanticModel);

    }
}
