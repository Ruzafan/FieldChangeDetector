using Microsoft.CodeAnalysis;

namespace Generator.Mappers
{
    public interface ISyntaxMapper<TResult>
    {

        TResult MapSyntax(SyntaxNode syntaxNode, SemanticModel semanticModel);

    }
}
