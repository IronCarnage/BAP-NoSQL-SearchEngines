``` ini

BenchmarkDotNet=v0.12.1, 
OS=Windows 10.0.18363.1556 (1909/November2018Update/19H2)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4360.0), X86 LegacyJIT
  Job-FAOBRV : .NET Framework 4.8 (4.8.4360.0), X86 LegacyJIT

IterationCount=50  
WarmupCount=10  

```
|                     Method | take | page |         searchTerm |         Mean |      Error |     StdDev | Ratio | RatioSD |     Gen 0 |    Gen 1 |   Gen 2 |  Allocated |
|--------------------------- |----- |----- |------------------- |-------------:|-----------:|-----------:|------:|--------:|----------:|---------:|--------:|-----------:|
| **CloudElasticQueryExecution** |   **10** |    **1** |                  ***** |   **340.227 ms** |  **3.9149 ms** |  **7.7277 ms** | **1.000** |    **0.00** |         **-** |        **-** |       **-** |  **280.21 KB** |
| LocalElasticQueryExecution |   10 |    1 |                  * |     6.841 ms |  0.4590 ms |  0.9167 ms | 0.020 |    0.00 |         - |        - |       - |      80 KB |
|        AzureQueryExecution |   10 |    1 |                  * |   339.645 ms |  2.5017 ms |  4.9961 ms | 0.998 |    0.03 |         - |        - |       - |      64 KB |
|         SolrQueryExecution |   10 |    1 |                  * |     2.410 ms |  0.0492 ms |  0.0961 ms | 0.007 |    0.00 |   42.9688 |        - |       - |  135.63 KB |
|                            |      |      |                    |              |            |            |       |         |           |          |         |            |
| **CloudElasticQueryExecution** |   **10** |    **1** |             **VPE=10** |   **327.680 ms** |  **3.6113 ms** |  **7.1284 ms** | **1.000** |    **0.00** |         **-** |        **-** |       **-** |  **280.21 KB** |
| LocalElasticQueryExecution |   10 |    1 |             VPE=10 |     8.687 ms |  0.6752 ms |  1.3639 ms | 0.026 |    0.00 |         - |        - |       - |      88 KB |
|        AzureQueryExecution |   10 |    1 |             VPE=10 |   329.828 ms |  2.2475 ms |  4.4884 ms | 1.006 |    0.02 |         - |        - |       - |      72 KB |
|         SolrQueryExecution |   10 |    1 |             VPE=10 |     2.603 ms |  0.0326 ms |  0.0658 ms | 0.008 |    0.00 |   42.9688 |        - |       - |  143.04 KB |
|                            |      |      |                    |              |            |            |       |         |           |          |         |            |
| **CloudElasticQueryExecution** |   **10** |    **1** | **dompelpomp \|\| 400V** |   **337.693 ms** |  **3.7742 ms** |  **7.4500 ms** | **1.000** |    **0.00** |         **-** |        **-** |       **-** |  **280.21 KB** |
| LocalElasticQueryExecution |   10 |    1 | dompelpomp \|\| 400V |     7.037 ms |  0.5492 ms |  1.1094 ms | 0.021 |    0.00 |         - |        - |       - |      80 KB |
|        AzureQueryExecution |   10 |    1 | dompelpomp \|\| 400V |   330.879 ms |  2.1501 ms |  4.1936 ms | 0.980 |    0.03 |         - |        - |       - |      72 KB |
|         SolrQueryExecution |   10 |    1 | dompelpomp \|\| 400V |     2.304 ms |  0.0559 ms |  0.1116 ms | 0.007 |    0.00 |   42.9688 |        - |       - |  136.48 KB |
|                            |      |      |                    |              |            |            |       |         |           |          |         |            |
| **CloudElasticQueryExecution** |  **250** |    **3** |                  ***** |   **594.485 ms** |  **8.4773 ms** | **16.9301 ms** |  **1.00** |    **0.00** |         **-** |        **-** |       **-** | **2430.05 KB** |
| LocalElasticQueryExecution |  250 |    3 |                  * |    17.042 ms |  0.8235 ms |  1.6635 ms |  0.03 |    0.00 |         - |        - |       - |  960.05 KB |
|        AzureQueryExecution |  250 |    3 |                  * |   399.013 ms |  4.0258 ms |  8.0399 ms |  0.67 |    0.02 |         - |        - |       - |  740.11 KB |
|         SolrQueryExecution |  250 |    3 |                  * |    41.052 ms |  1.1838 ms |  2.3913 ms |  0.07 |    0.00 |  250.0000 |  83.3333 |       - |    1818 KB |
|                            |      |      |                    |              |            |            |       |         |           |          |         |            |
| **CloudElasticQueryExecution** |  **250** |    **3** |             **VPE=10** |   **641.445 ms** |  **7.8647 ms** | **14.9634 ms** |  **1.00** |    **0.00** |         **-** |        **-** |       **-** | **1286.06 KB** |
| LocalElasticQueryExecution |  250 |    3 |             VPE=10 |    37.809 ms |  1.6651 ms |  3.2867 ms |  0.06 |    0.00 |         - |        - |       - |  944.05 KB |
|        AzureQueryExecution |  250 |    3 |             VPE=10 |   390.558 ms |  2.7752 ms |  5.3468 ms |  0.61 |    0.02 |         - |        - |       - |  636.11 KB |
|         SolrQueryExecution |  250 |    3 |             VPE=10 |    29.695 ms |  0.3183 ms |  0.6057 ms |  0.05 |    0.00 |  312.5000 | 125.0000 | 62.5000 | 1679.62 KB |
|                            |      |      |                    |              |            |            |       |         |           |          |         |            |
| **CloudElasticQueryExecution** |  **250** |   **12** | **dompelpomp \|\| 400V** | **1,892.480 ms** | **26.3473 ms** | **52.0070 ms** | **1.000** |    **0.00** | **1000.0000** |        **-** |       **-** | **4497.34 KB** |
| LocalElasticQueryExecution |  250 |   12 | dompelpomp \|\| 400V |   121.239 ms |  1.4634 ms |  2.8195 ms | 0.064 |    0.00 |         - |        - |       - |  3541.9 KB |
|        AzureQueryExecution |  250 |   12 | dompelpomp \|\| 400V |   350.832 ms |  2.6098 ms |  5.0282 ms | 0.186 |    0.01 |         - |        - |       - |  350.08 KB |
|         SolrQueryExecution |  250 |   12 | dompelpomp \|\| 400V |    16.402 ms |  0.1891 ms |  0.3644 ms | 0.009 |    0.00 |  156.2500 |  62.5000 | 31.2500 |  713.64 KB |
