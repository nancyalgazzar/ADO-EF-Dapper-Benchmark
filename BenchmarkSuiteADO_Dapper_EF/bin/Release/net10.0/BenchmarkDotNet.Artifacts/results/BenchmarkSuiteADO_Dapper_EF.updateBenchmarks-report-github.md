```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8037/25H2/2025Update/HudsonValley2)
Intel Core i7-10870H CPU 2.20GHz (Max: 2.21GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.201
  [Host]     : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3


```
| Method           | Mean     | Error   | StdDev  |
|----------------- |---------:|--------:|--------:|
| updateCoursesEF  | 337.1 μs | 6.31 μs | 6.48 μs |
| getCoursesDapper | 150.9 μs | 3.01 μs | 5.42 μs |
| getCoursesADO    | 147.7 μs | 2.52 μs | 2.59 μs |
