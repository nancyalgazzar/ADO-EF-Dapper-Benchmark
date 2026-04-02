```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8037/25H2/2025Update/HudsonValley2)
Intel Core i7-10870H CPU 2.20GHz (Max: 2.21GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.201
  [Host]     : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3


```
| Method           | Mean     | Error     | StdDev    |
|----------------- |---------:|----------:|----------:|
| getCoursesEF     | 2.886 ms | 0.0566 ms | 0.0652 ms |
| getCoursesDapper | 1.150 ms | 0.0136 ms | 0.0106 ms |
| getCoursesADO    | 1.143 ms | 0.0226 ms | 0.0542 ms |
