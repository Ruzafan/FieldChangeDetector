using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using Microsoft.CSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using RoslynComparatorGenerator;
using System.CodeDom.Compiler;
using System.Reflection;

namespace FieldsChangeDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var results = BenchmarkRunner.Run<DetectDiferentFieldsValues>();
        }



    }

    
}