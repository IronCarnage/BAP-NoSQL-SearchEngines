```ini

BenchmarkDotNet=v0.12.1, 
OS=Windows 10.0.18363.1556 (1909/November2018Update/19H2)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X86 LegacyJIT
  Job-FAOBRV : .NET Framework 4.8 (4.8.4341.0), X86 LegacyJIT

IterationCount=50  
WarmupCount=10  
```

| Method                 | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen 0       | Gen 1      | Gen 2      | Allocated |
| ---------------------- | ---------:| ---------:| ---------:| -----:| -------:| -----------:| ----------:| ----------:| ---------:|
| CloudElasticBuildIndex | 36.039 s  | 0.4004 s  | 0.7714 s  | 1.00  | 0.00    | 46000.0000  | 29000.0000 | 8000.0000  | 380.14 MB |
| LocalElasticBuildIndex | 9.611 s   | 0.2648 s  | 0.5288 s  | 0.27  | 0.02    | 42000.0000  | 30000.0000 | 9000.0000  | 406.47 MB |
| AzureBuildIndex        | 214.101 s | 15.6050 s | 31.5230 s | 5.92  | 0.88    | 114000.0000 | 26000.0000 | 8000.0000  | 554.19 MB |
| SolrBuildIndex         | 20.397 s  | 0.5449 s  | 1.0367 s  | 0.57  | 0.03    | 123000.0000 | 82000.0000 | 10000.0000 | 811.97 MB |
