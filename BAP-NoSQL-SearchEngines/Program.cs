using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BAP_NoSQL_SearchEngines.Models;
using BAP_NoSQL_SearchEngines.Repositories;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess;
using BenchmarkDotNet.Validators;

namespace BAP_NoSQL_SearchEngines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var summaryIndex = BenchmarkRunner.Run<IndexBenchmark>();
            var summarySearch = BenchmarkRunner.Run<SearchBenchmark>();

            Console.ReadKey();
        }
    }
}
