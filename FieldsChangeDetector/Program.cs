using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using Microsoft.CSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
//using RoslynComparatorGenerator;
using System.CodeDom.Compiler;
using System.Reflection;

namespace FieldsChangeDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
         //   var config = DefaultConfig.Instance
         //   .AddJob(Job
         //.MediumRun
         //.WithLaunchCount(1)
         //.WithToolchain(InProcessNoEmitToolchain.Instance));
         //   var results = BenchmarkRunner.Run<DetectDiferentFieldsValues>(config);

            var aux = new DetectDiferentFieldsValues();
            aux.CheckDiferentFieldsRoslyn();
        }



    }


}