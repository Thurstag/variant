
using BenchmarkDotNet.Attributes;
using OneOf;
using Union;

namespace System.Benchmarks; 

/// <summary>
/// Benchmark of <see cref="Variant{T0}.Map{T}(Func{T0, T})"/>
/// </summary>
[VeryLongRunJob]
[DisassemblyDiagnoser, MemoryDiagnoser]
public class MapBenchmark {
    
    private const int Value = 42;
    
    private readonly Variant<int> _variant = Value;
    private OneOf<int> _oneOf = Value;
    private readonly Union<int> _union = Value;
    private readonly UnionClass<int> _unionClass = Value;
    
    [Benchmark(Baseline = true)]
    public int Variant() => _variant.Map(t => t.GetHashCode());
    
    [Benchmark]
    public int OneOf() => _oneOf.Match(t => t.GetHashCode());
    
    [Benchmark]
    public int Union() => _union.Switch(t => t.GetHashCode());
    
    [Benchmark]
    public int UnionClass() => _unionClass.Switch(t => t.GetHashCode());
}