``` ini

BenchmarkDotNet=v0.12.1, 
OS=Windows 10.0.18363.1556 (1909/November2018Update/19H2)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4360.0), X86 LegacyJIT
  Job-FAOBRV : .NET Framework 4.8 (4.8.4360.0), X86 LegacyJIT

IterationCount=50 
WarmupCount=10  

```
|                 Method |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |       Gen 0 |      Gen 1 |      Gen 2 | Allocated |
|----------------------- |---------:|---------:|---------:|---------:|------:|--------:|------------:|-----------:|-----------:|----------:|
| CloudElasticBuildIndex |  37.75 s |  0.701 s |  1.416 s |  37.45 s |  1.00 |    0.00 |  47000.0000 | 28000.0000 |  8000.0000 |  380.1 MB |
| LocalElasticBuildIndex |  10.01 s |  0.238 s |  0.480 s |  10.08 s |  0.27 |    0.02 |  43000.0000 | 31000.0000 |  9000.0000 | 406.38 MB |
|        AzureBuildIndex | 250.92 s | 13.857 s | 27.027 s | 248.08 s |  6.65 |    0.85 | 114000.0000 | 26000.0000 |  8000.0000 | 554.15 MB |
|         SolrBuildIndex |  21.15 s |  0.444 s |  0.876 s |  21.51 s |  0.56 |    0.03 | 122000.0000 | 81000.0000 | 10000.0000 | 811.82 MB |
