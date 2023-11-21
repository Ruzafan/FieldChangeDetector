using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ChangeDetectableCodeGenerator.Models
{
    public class FieldInfo : IParameter
    {

        /// <summary>
        /// The type of the field.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The name of the field.
        /// </summary>
        public string Name { get; set; }
        public bool IsGeneric { get; internal set; }
        public bool IsMongo { get; internal set; }
    }
}
