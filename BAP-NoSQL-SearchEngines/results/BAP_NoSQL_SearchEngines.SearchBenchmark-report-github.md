```ini

BenchmarkDotNet=v0.12.1,
OS=Windows 10.0.18363.1556 (1909/November2018Update/19H2)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X86 LegacyJIT
  Job-FAOBRV : .NET Framework 4.8 (4.8.4341.0), X86 LegacyJIT

IterationCount=50  
WarmupCount=10  
```

| Method                         | take    | page   | searchTerm               | Mean             | Error          | StdDev         | Median           | Ratio     | RatioSD  | Gen 0         | Gen 1        | Gen 2   | Allocated      |
| ------------------------------ | ------- | ------ | ------------------------ | ----------------:| --------------:| --------------:| ----------------:| ---------:| --------:| -------------:| ------------:| -------:| --------------:|
| **CloudElasticQueryExecution** | **10**  | **1**  | *****                    | **330.842 ms**   | **3.4479 ms**  | **6.5601 ms**  | **329.118 ms**   | **1.000** | **0.00** | **-**         | **-**        | **-**   | **296.21 KB**  |
| LocalElasticQueryExecution     | 10      | 1      | *                        | 6.552 ms         | 0.4169 ms      | 0.8327 ms      | 6.441 ms         | 0.020     | 0.00     | -             | -            | -       | 80 KB          |
| AzureQueryExecution            | 10      | 1      | *                        | 325.566 ms       | 1.3283 ms      | 2.5591 ms      | 324.902 ms       | 0.985     | 0.02     | -             | -            | -       | 64 KB          |
| SolrQueryExecution             | 10      | 1      | *                        | 2.368 ms         | 0.1028 ms      | 0.2076 ms      | 2.244 ms         | 0.007     | 0.00     | 42.9688       | -            | -       | 135.62 KB      |
|                                |         |        |                          |                  |                |                |                  |           |          |               |              |         |                |
| **CloudElasticQueryExecution** | **10**  | **1**  | **VPE=10**               | **334.185 ms**   | **4.9836 ms**  | **9.8372 ms**  | **333.345 ms**   | **1.000** | **0.00** | **-**         | **-**        | **-**   | **280.21 KB**  |
| LocalElasticQueryExecution     | 10      | 1      | VPE=10                   | 10.034 ms        | 0.9842 ms      | 1.9881 ms      | 9.825 ms         | 0.030     | 0.01     | -             | -            | -       | 88 KB          |
| AzureQueryExecution            | 10      | 1      | VPE=10                   | 337.088 ms       | 3.2340 ms      | 6.3837 ms      | 334.527 ms       | 1.010     | 0.04     | -             | -            | -       | 64 KB          |
| SolrQueryExecution             | 10      | 1      | VPE=10                   | 2.612 ms         | 0.0359 ms      | 0.0700 ms      | 2.590 ms         | 0.008     | 0.00     | 42.9688       | -            | -       | 143.08 KB      |
|                                |         |        |                          |                  |                |                |                  |           |          |               |              |         |                |
| **CloudElasticQueryExecution** | **10**  | **1**  | **dompelpomp \|\| 400V** | **332.077 ms**   | **2.7214 ms**  | **5.3078 ms**  | **331.189 ms**   | **1.000** | **0.00** | -             | -            | **-**   | **280.21KB**   |
| LocalElasticQueryExecution     | 10      | 1      | dompelpomp \|\| 400V     | 7.727 ms         | 0.5762 ms      | 1.1640 ms      | 7.549 ms         | 0.023     | 0.00     | -             | -            | -       | 80KB           |
| AzureQueryExecution            | 10      | 1      | dompelpomp \|\| 400V     | 325.839 ms       | 1.5869 ms      | 3.0951 ms      | 325.167 ms       | 0.981     | 0.02     | -             | -            | -       | 64 KB          |
| SolrQueryExecution             | 10      | 1      | dompelpomp \|\| 400V     | 2.435 ms         | 0.0828 ms      | 0.1672 ms      | 2.471 ms         | 0.007     | 0.00     | 42.9688       | -            | -       | 136.74 KB      |
|                                |         |        |                          |                  |                |                |                  |           |          |               |              |         |                |
| **CloudElasticQueryExecution** | **250** | **3**  | *****                    | **580.789 ms**   | **5.6016 ms**  | **11.0570 ms** | **579.022 ms**   | **1.00**  | **0.00** | **-**         | **-**        | **-**   | **2052.75 KB** |
| LocalElasticQueryExecution     | 250     | 3      | *                        | 21.759 ms        | 1.3756 ms      | 2.7787 ms      | 21.805 ms        | 0.04      | 0.00     | -             | -            | -       | 960.05 KB      |
| AzureQueryExecution            | 250     | 3      | *                        | 354.448 ms       | 3.0319 ms      | 5.9847 ms      | 353.651 ms       | 0.61      | 0.01     | -             | -            | -       | 192.34 KB      |
| SolrQueryExecution             | 250     | 3      | *                        | 40.885 ms        | 1.1798 ms      | 2.3288 ms      | 40.697 ms        | 0.07      | 0.00     | 250.0000      | 83.3333      | -       | 1818.67 KB     |
|                                |         |        |                          |                  |                |                |                  |           |          |               |              |         |                |
| **CloudElasticQueryExecution** | **250** | **3**  | **VPE=10**               | **630.904 ms**   | **11.6856 ms** | **22.7918 ms** | **629.771 ms**   | **1.00**  | **0.00** | **-**         | **-**        | **-**   | **1281.55 KB** |
| LocalElasticQueryExecution     | 250     | 3      | VPE=10                   | 37.601 ms        | 1.6740 ms      | 3.1850 ms      | 37.511 ms        | 0.06      | 0.01     | -             | -            | -       | 944.05 KB      |
| AzureQueryExecution            | 250     | 3      | VPE=10                   | 367.129 ms       | 2.7260 ms      | 5.3808 ms      | 365.539 ms       | 0.58      | 0.02     | -             | -            | -       | 193.56 KB      |
| SolrQueryExecution             | 250     | 3      | VPE=10                   | 28.225 ms        | 0.6398 ms      | 1.2924 ms      | 27.637 ms        | 0.04      | 0.00     | 333.3333      | 133.3333     | 66.6667 | 1680.88 KB     |
|                                |         |        |                          |                  |                |                |                  |           |          |               |              |         |                |
| **CloudElasticQueryExecution** | **250** | **12** | **dompelpomp \|\| 400V** | **1,872.885 ms** | **30.8901 ms** | **59.5148 ms** | **1,886.038 ms** | **1.000** | **0.00** | **1000.0000** | **133.3333** | **-**   | **4555.04 KB** |
| LocalElasticQueryExecution     | 250     | 12     | dompelpomp \|\| 400V     | 119.272 ms       | 1.6944 ms      | 3.1824 ms      | 119.298 ms       | 0.064     | 0.00     | -             | -            | -       | 3535.68 KB     |
| .AzureQueryExecution           | 250     | 12     | dompelpomp \|\| 400V     | 337.681 ms       | 2.0013 ms      | 3.9033 ms      | 337.225 ms       | 0.181     | 0.01     | -             | -            | -       | 96 KB          |
| SolrQueryExecution             | 250     | 12     | dompelpomp \|\| 400V     | 16.464 ms        | 0.2223 ms      | 0.4230 ms      | 16.394 ms        | 0.009     | 0.00     | 156.2500      | 62.500       | 31.2500 | 712.98 KB      |
