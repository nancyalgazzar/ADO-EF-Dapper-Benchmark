using BenchmarkDotNet.Running;
using BenchmarkSuiteADO_Dapper_EF.Context;
using BenchmarkSuiteADO_Dapper_EF.Fakers;
using System;
using static BenchmarkSuiteADO_Dapper_EF.updateBenchmarks;

namespace BenchmarkSuiteADO_Dapper_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher benchmarkSwitcher = new BenchmarkSwitcher([
                //typeof(Benchmarks),
                //typeof(selectallBenchmarks),
                //typeof(updateBenchmarks),
                typeof(selectallInstructorBenchmarks),
                //typeof(selectallallBenchmarks),
                ]);
            benchmarkSwitcher.RunAll();
  
            //var _ = BenchmarkRunner.Run(typeof(Program).Assembly);

            //using testContext testContext = new testContext();
            //var instructors = new InstructorFaker().Generate(100);
            //testContext.AddRange(instructors);
            //Console.WriteLine( testContext.SaveChanges());
        }
    }
}
