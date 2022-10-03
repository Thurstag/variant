
using System.Security.Cryptography;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using OneOf;
using Union;

namespace System.Benchmarks; 

/// <summary>
/// Benchmark of <see cref="Variant{T0, T1, T2}.Map{T}(Func{T0, T}, Func{T1, T}, Func{T2, T})"/>
/// </summary>
[VeryLongRunJob]
[DisassemblyDiagnoser, MemoryDiagnoser]
public class MapOutOf3Benchmark {

    private readonly Variant<int, string, TaskCreationOptions> _variant;
    private OneOf<int, string, TaskCreationOptions> _oneOf;
    private readonly Union<int, string, TaskCreationOptions> _union;
    private readonly UnionClass<int, string, TaskCreationOptions> _unionClass;
    
    public MapOutOf3Benchmark() {
        switch (RandomNumberGenerator.GetInt32(0, 3)) {
            case 0:
                const int i = 42;
                _variant = i;
                _oneOf = i;
                _union = i;
                _unionClass = i;
                break;
            
            case 1:
                const string str = "test";
                _variant = str;
                _oneOf = str;
                _union = str;
                _unionClass = str;
                break;
            
            case 2:
                const TaskCreationOptions opt = TaskCreationOptions.None;
                _variant = opt;
                _oneOf = opt;
                _union = opt;
                _unionClass = opt;
                break;
            
            default:
                throw new InvalidOperationException("Unreachable code");
        }
    }

    [Benchmark(Baseline = true)]
    public int Variant() => _variant.Map(t => t.GetHashCode(), t => t.GetHashCode(), t => t.GetHashCode());
    
    [Benchmark]
    public int OneOf() => _oneOf.Match(t => t.GetHashCode(), t => t.GetHashCode(), t => t.GetHashCode());
    
    [Benchmark]
    public int Union() => _union.Switch(t => t.GetHashCode(), t => t.GetHashCode(), t => t.GetHashCode());
    
    [Benchmark]
    public int UnionClass() => _unionClass.Switch(t => t.GetHashCode(), t => t.GetHashCode(), t => t.GetHashCode());
}