namespace System.Benchmarks;

/// <summary>
/// Benchmark of variants holding 3 primitive types
/// </summary>
public class Map3PrimitivesBenchmark : Map3Benchmark<int, double, byte> {
    /// <summary>
    /// Default constructor
    /// </summary>
    public Map3PrimitivesBenchmark() : base(() => 42, () => 6, () => 99) { }
}