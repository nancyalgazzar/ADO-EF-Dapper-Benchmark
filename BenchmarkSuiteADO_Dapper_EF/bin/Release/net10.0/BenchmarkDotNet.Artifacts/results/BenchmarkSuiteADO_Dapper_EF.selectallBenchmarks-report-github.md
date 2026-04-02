```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8037/25H2/2025Update/HudsonValley2)
Intel Core i7-10870H CPU 2.20GHz (Max: 2.21GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.201
  [Host]     : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3


```
| Method           | Mean     | Error    | StdDev   |
|----------------- |---------:|---------:|---------:|
| getCoursesEF     | 563.9 μs | 11.18 μs | 22.32 μs |
| getCoursesDapper | 231.1 μs |  2.77 μs |  2.45 μs |
| getCoursesADO    | 235.3 μs |  4.62 μs |  6.32 μs |
