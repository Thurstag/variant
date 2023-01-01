// Copyright 2022-2023 variant Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System.Collections.Generic;
using System.Threading;

namespace System.Benchmarks;

/// <summary>
/// Benchmark of variants holding 3 class types
/// </summary>
public class Map3ClassesBenchmark : Map3Benchmark<Thread, string, List<int>> {
    /// <summary>
    /// Default constructor
    /// </summary>
    public Map3ClassesBenchmark() : base(() => Thread.CurrentThread, () => "test", () => new List<int>(new[] { 6, 42 })) { }
}